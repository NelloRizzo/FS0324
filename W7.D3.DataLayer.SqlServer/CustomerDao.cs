using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W7.D3.DataLayer.Dao;
using W7.D3.DataLayer.Data.Customers;

namespace W7.D3.DataLayer.SqlServer
{
    /// <summary>
    /// Gestore dei clienti con SQLServer.
    /// </summary>
    /// <remarks>
    /// La scelta è stata quella di implementare una gerarchia in cui ogni sottoclasse
    /// memorizza i propri dati in una tabella a sé stante. Il legame tra le tabelle è
    /// implementato tramite l'Id in maniera tale che i dati comuni si trovino nella
    /// tabella "Customers" e i dati specifici nelle tabelle "People" e "Companies":
    /// per recuperare un dato completo occorre effettuare un JOIN tra le due tabelle
    /// sul campo Id di entrambe.
    /// </remarks>
    public class CustomerDao : BaseDao, ICustomerDao
    {
        // il dato inserito in Customers determina l'Id delle tabelle collegate
        private const string INSERT_CUSTOMER = "INSERT INTO Customers(Discriminator, Address, City, Region, PostalCode) " +
            "OUTPUT INSERTED.Id VALUES(@discriminator, @address, @city, @region, @postalCode)";
        // il campo Id di Person non è IDENTITY ma va specificato sulla base del record inserito in Customers
        private const string INSERT_PERSON = "INSERT INTO People(Id, FirstName, LastName, FiscalCode) " +
            "VALUES(@id, @firstName, @lastName, @fiscalCode)";
        // il campo Id di Company non è IDENTITY ma va specificato sulla base del record inserito in Customers
        private const string INSERT_COMPANY = "INSERT INTO Companies(Id, Name, VatCode) VALUES(@id, @name, @vatCode)";
        /// <summary>
        /// Recupero di privati.
        /// </summary>
        private const string SELECT_PEOPLE = "SELECT " +
            "Address, City, Region, PostalCode, Discriminator, " +
            "t.Id AS Id, FirstName, LastName, FiscalCode AS FiscalData " +
            "FROM Customers cu JOIN People t ON cu.Id = t.Id ";
        /// <summary>
        /// Recupero di aziende.
        /// </summary>
        private const string SELECT_COMPANIES = "SELECT " +
            "Address, City, Region, PostalCode, Discriminator, " +
            // la presenza del campo costante ('N/A') è giustificata dal fatto che
            // per il recupero di privati e aziende effettuo una query con UNION
            // e, in tal caso, occorre che entrambe le query unite abbiano lo stesso numero di campi
            "t.Id AS Id, Name, 'N/A', VatCode AS FiscalData " +
            "FROM Customers cu JOIN Companies t ON cu.Id = t.Id";
        /// <summary>
        /// Recupero di TUTTI i clienti.
        /// </summary>
        private const string SELECT_CUSTOMERS = SELECT_PEOPLE + " UNION " + SELECT_COMPANIES;
        /// <summary>
        /// Recupero di un cliente tramite Id.
        /// </summary>
        private const string SELECT_CUSTOMER_BY_ID = SELECT_CUSTOMERS + " WHERE t.Id = @id";
        public CustomerDao(IConfiguration configuration, ILogger<UserDao> logger) : base(configuration, logger) { }

        private static void InsertPerson(PersonEntity person, SqlTransaction transaction) {
            using var cmd = new SqlCommand(INSERT_PERSON, transaction.Connection, transaction);
            cmd.Parameters.AddRange([
                new SqlParameter("@id", person.Id),
                new SqlParameter("@firstName", person.FirstName),
                new SqlParameter("@lastName", person.LastName),
                new SqlParameter("@fiscalCode", person.FiscalCode)
                ]);
            cmd.ExecuteNonQuery();
        }
        private static void InsertCompany(CompanyEntity company, SqlTransaction transaction) {
            using var cmd = new SqlCommand(INSERT_COMPANY, transaction.Connection, transaction);
            cmd.Parameters.AddRange([
                new SqlParameter("@id", company.Id),
                new SqlParameter("@name", company.Name),
                new SqlParameter("@vatCode", company.VatCode)
                ]);
            cmd.ExecuteNonQuery();
        }
        public CustomerEntity Create(CustomerEntity customer) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var trans = conn.BeginTransaction();
                using var cmd = new SqlCommand(INSERT_CUSTOMER, conn, trans);
                cmd.Parameters.AddRange([
                    new SqlParameter("@address", customer.Address),
                    new SqlParameter("@discriminator", customer.Discriminator),
                    new SqlParameter("@city", customer.City),
                    new SqlParameter("@region", (object?)customer.Region ?? DBNull.Value),
                    new SqlParameter("@postalCode", customer.PostalCode)
                ]);
                customer.Id = (int)cmd.ExecuteScalar();
                if (customer is PersonEntity person) InsertPerson(person, trans);
                else if (customer is CompanyEntity company) InsertCompany(company, trans);
                else
                    throw new Exception("Unknown customer entity");
                trans.Commit();
                return Read(customer.Id);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating customer");
                throw;
            }
        }

        private static PersonEntity MapPerson(SqlDataReader reader) => new PersonEntity {
            Address = reader.GetString(0),
            City = reader.GetString(1),
            Region = reader.IsDBNull(2) ? null : reader.GetString(2),
            PostalCode = reader.GetString(3),
            Id = reader.GetInt32(5),
            FirstName = reader.GetString(6),
            LastName = reader.GetString(7),
            FiscalCode = reader.GetString(8)
        };
        private static CompanyEntity MapCompany(SqlDataReader reader) => new CompanyEntity {
            Address = reader.GetString(0),
            City = reader.GetString(1),
            Region = reader.IsDBNull(2) ? null : reader.GetString(2),
            PostalCode = reader.GetString(3),
            Id = reader.GetInt32(5),
            Name = reader.GetString(6),
            VatCode = reader.GetString(8)
        };
        private static CustomerEntity Map(SqlDataReader reader) {
            if (Convert.ToInt32(reader["Discriminator"]) == (int)TypeDiscriminator.Person)
                return MapPerson(reader);
            return MapCompany(reader);
        }
        public CustomerEntity Read(int customerId) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_CUSTOMER_BY_ID, conn);
                cmd.Parameters.AddWithValue("@id", customerId);
                using var reader = cmd.ExecuteReader();
                if (reader.Read()) return Map(reader);
                throw new Exception("Customer with id = {customerId} not found");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting customer");
                throw;
            }
        }

        public IEnumerable<CustomerEntity> ReadAll() {
            try {
                var result = new List<CustomerEntity>();
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_CUSTOMERS, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) result.Add(Map(reader));
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting customer");
                throw;
            }
        }
    }
}

using System.Data.Common;
using System.Data.SqlClient;
using W3.D4.DailyProject.Models;

namespace W3.D4.DailyProject.Services
{
    public class ImpiegatoService : IImpiegatoService
    {
        private readonly SqlConnection _connection;
        public ImpiegatoService(IConfiguration config) {
            _connection = new SqlConnection(config.GetConnectionString("AppDb"));
        }
        public void AssumiImpiegato(Impiegato impiegato, Impiego impiego) {
            try {
                _connection.Open();
                // attiva un "workspace" privato chiamato "transazione"
                // tutto quello che facciamo in una transazione è locale
                // sarà reso pubblico solo al commissionamento della transazione
                var trans = _connection.BeginTransaction();

                var queryInsertImpiego = "INSERT INTO Impiego(TipoImpiego, Assunzione) VALUES(@tipo, @data)";
                var queryLastImpiego = "SELECT TOP(1) Id FROM Impiego ORDER BY Id DESC";
                var queryInsertImpiegato = "INSERT INTO " +
                    "Impiegato(Cognome, Nome, CodiceFiscale, Eta, RedditoMensile, DetrazioneFiscale, ImpiegoFK) " +
                    "VALUES(@cognome, @nome, @cf, @eta, @reddito, @detrazione, @fk)";

                using var cmdInsertImpiego = new SqlCommand(queryInsertImpiego, _connection, trans);
                cmdInsertImpiego.Parameters.AddWithValue("@tipo", impiego.TipoImpiego);
                cmdInsertImpiego.Parameters.AddWithValue("@data", impiego.Assunzione);
                cmdInsertImpiego.ExecuteNonQuery();

                using var cmdGetLastId = new SqlCommand(queryLastImpiego, _connection, trans);
                var lastId = (int)cmdGetLastId.ExecuteScalar();

                using var cmdInsertImpiegato = new SqlCommand(queryInsertImpiegato, _connection, trans);
                cmdInsertImpiegato.Parameters.AddWithValue("@cognome", impiegato.Cognome);
                cmdInsertImpiegato.Parameters.AddWithValue("@nome", impiegato.Nome);
                cmdInsertImpiegato.Parameters.AddWithValue("@cf", impiegato.CodiceFiscale);
                cmdInsertImpiegato.Parameters.AddWithValue("@eta", impiegato.Eta);
                cmdInsertImpiegato.Parameters.AddWithValue("@reddito", impiegato.RedditoMensile);
                cmdInsertImpiegato.Parameters.AddWithValue("@detrazione", impiegato.DetrazioneFiscale);
                cmdInsertImpiegato.Parameters.AddWithValue("@fk", lastId);
                cmdInsertImpiegato.ExecuteNonQuery();
                // rende pubbliche tutte le modifiche
                trans.Commit();
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
            }
            finally {
                _connection.Close();
            }
        }

        public void CambiaImpiego(int impiegatoId, Impiego impiego) {
            throw new NotImplementedException();
        }

        public IEnumerable<Impiegato> GetAll(decimal reddito) {
            try {
                _connection.Open();
                var query = "SELECT i.Id, i.Cognome, i.Nome, i.CodiceFiscale, i.Eta, i.RedditoMensile, i.DetrazioneFiscale," +
                    "m.TipoImpiego, m.Assunzone " +
                    "FROM Impiegato i INNER JOIN Impiego m ON i.ImpiegoFk = m.Id " +
                    "WHERE RedditoMensile >= @reddito";
                using var cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@reddito", reddito);
                using var reader = cmd.ExecuteReader();
                var list = new List<Impiegato>();
                while (reader.Read()) {
                    list.Add(new Impiegato {
                        CodiceFiscale = reader.GetString(3),
                        Cognome = reader.GetString(1),
                        DetrazioneFiscale = reader.GetBoolean(6),
                        Eta = reader.GetInt32(4),
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(2),
                        RedditoMensile = reader.GetDecimal(5)
                    });
                }
                return list;
            }
            catch {
                return [];
            }
            finally {
                _connection.Close();
            }
        }
    }
}

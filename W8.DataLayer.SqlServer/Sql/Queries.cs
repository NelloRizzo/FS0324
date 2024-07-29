namespace W8.DataLayer.SqlServer.Sql
{
    /// <summary>
    /// Contiene tutte le queries SQL suddivisi per tabella.
    /// </summary>
    internal static class Queries
    {
        public const string COUNT_FORMAT = "SELECT COUNT(*) FROM {0}";
        public const string DELETE_FORMAT = "DELETE FROM {0} WHERE Id = @id";

        /// <summary>
        /// Tabella degli utenti.
        /// </summary>
        internal static class Users
        {
            public const string INSERT = "INSERT INTO Users(Username, Email, Password) " +
                "OUTPUT INSERTED.Id " +
                "VALUES(@username, @email, @password)";
            public const string SELECT_ALL =
                "WITH CTE_UserRoles AS (" +
                "   SELECT UserId, RoleName AS Roles FROM Roles ro JOIN UsersRoles ur ON ur.RoleId = ro.Id " +
                ")" +
                "SELECT " +
                // STRING_AGG unisce in una stringa i valori recuperati dall'aggregazione
                "   Id, Username, Email, Password, STRING_AGG(Roles, ',') AS Roles" +
                "FROM Users us JOIN CTE_UserRoles ur ON us.Id = ur.UserId" +
                "GROUP BY Id, Username, Email, Password";
            public const string SELECT_BY_USERNAME = SELECT_ALL + " WHERE Username = @username";
            public const string SELECT_BY_USERNAME_AND_PASSWORD = SELECT_ALL +
                " WHERE Username = @username AND Password = @password";
            public const string SELECT_BY_ID = SELECT_ALL + " WHERE Id = @id";
        }
        /// <summary>
        /// Tabella dei ruoli.
        /// </summary>
        internal static class Roles
        {
            public const string INSERT = "INSERT INTO Roles(RoleName) OUTPUT INSERTED.Id VALUES(@roleName)";
            public const string SELECT_ALL = "SELECT Id, RoleName FROM Roles";
        }
        /// <summary>
        /// Tabella dei ruoli utente.
        /// </summary>
        internal static class UsersRoles
        {
            public const string INSERT = "INSERT INTO UsersRoles(UserId, RoleId) VALUES (@userId, @roleId)";
            public const string SELECT_BY_USERID = "SELECT RoleName " +
                "FROM UsersRoles ur JOIN Roles ro ON ur.RoleId = ro.Id " +
                "WHERE UserId = @userId";
        }
        /// <summary>
        /// Tabella delle città.
        /// </summary>
        internal static class Cities
        {
            public const string INSERT = "INSERT " +
                "INTO Cities(Id, Name, Cadastral, Capital, ProvinceId) " +
                "OUTPUT INSERTED.Id " +
                "VALUES(@id, @name, @cadastral, @capital, @provinceId)";

            public const string SELECT_ALL = "SELECT " +
                "Id, Name, Cadastral, Capital, ProvinceId " +
                "FROM Cities " +
                "ORDER BY Name";
            public const string SELECT_BY_ID = SELECT_ALL + " WHERE Id = @id";
            public const string SELECT_BY_PROVINCE = "SELECT " +
                "c.Id, c.Name, c.Cadastral, c.Capital, c.ProvinceId " +
                "FROM Cities c JOIN Provinces p ON c.ProvinceId = p.Id " +
                "WHERE p.Acronym = @acronym " +
                "ORDER BY c.Name";
            public const string UPDATE = "UPDATE Cities " +
                "SET Name = @name, Cadastral = @cadastral, Capital = @capital, ProvinceId = @provinceId " +
                "WHERE Id = @id";
        }
        /// <summary>
        /// Tabella delle province.
        /// </summary>
        internal static class Provinces
        {
            public const string INSERT = "INSERT " +
                "INTO Provinces(Id, Name, Acronym) " +
                "OUTPUT INSERTED.Id " +
                "VALUES(@id, @name, @acronym)";

            public const string SELECT_ALL = "SELECT " +
                "Id, Name, Acronym " +
                "FROM Provinces";
            public const string SELECT_BY_ID = SELECT_ALL + " WHERE Id = @id";
            public const string SELECT_BY_ACRONYM = SELECT_ALL + " WHERE Acronym = @acronym";
            public const string UPDATE = "UPDATE Provinces " +
                "SET Name = @name, Acronym = @acronym " +
                "WHERE Id = @id";
        }
        /// <summary>
        /// Tabella dei clienti.
        /// </summary>
        internal static class Customers
        {
            public const string INSERT = "INSERT " +
                "INTO Customers(LastName, FirstName, City, Province, FiscalCode, Phone, Mobile, Email) " +
                "OUTPUT INSERTED.Id " +
                "VALUES(@lastName, @firstName, @city, @province, @fiscalCode, @phone, @mobile, @email)";
            public const string SELECT_ALL = "SELECT " +
                "Id, LastName, FirstName, City, Province, FiscalCode, Phone, Mobile, Email " +
                "FROM Customers";
            public const string SELECT_BY_ID = SELECT_ALL + " WHERE Id = @id";
            public const string SELECT_PAGE = SELECT_ALL +
                " ORDER BY LastName, FirstName " +
                " OFFSET @skip ROWS " +
                " FETCH NEXT @fetch ROWS ONLY";
            public const string UPDATE = "UPDATE Customers " +
                "SET LastName = @lastName, FirstName = @firstName, City = @city, Province = @province, " +
                "FiscalCode = @fiscalCode, Phone = @phone, Mobile = @mobile, Email = @email " +
                "WHERE Id = @id";
        }
    }
}

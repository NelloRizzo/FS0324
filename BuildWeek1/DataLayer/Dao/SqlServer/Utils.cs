namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    public static class Utils
    {
        /// <summary>
        /// Applicato su una sorgente <strong>source</strong> restituisce il primo valore non nullo
        /// tra quelli eventualmente specificati come parametro, altrimenti restituisce il valore
        /// <strong>DBNull</strong> che rappresenta un dato <strong>NULL</strong> sul database.
        /// </summary>
        /// <param name="source">Oggetto da gestire.</param>
        /// <param name="values">Elenco da cui scegliere il primo valore non nullo.</param>
        /// <returns>Il primo valore non nullo tra quelli forniti oppure <strong>DBNull</strong>.</returns>
        public static object Coalesce(this object? source, params object[]? values) =>
            source ?? values?.FirstOrDefault(v => v != null) ?? DBNull.Value;
    }
}

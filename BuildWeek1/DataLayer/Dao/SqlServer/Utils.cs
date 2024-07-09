namespace BuildWeek1.DataLayer.Dao.SqlServer
{
    public static class Utils
    {
        public static object Coalesce(this object? source) => source ?? DBNull.Value;
    }
}

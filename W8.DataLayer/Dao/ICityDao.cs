using W8.DataLayer.Entities;

namespace W8.DataLayer.Dao
{
    /// <summary>
    /// DAO per le città.
    /// </summary>
    public interface ICityDao : IDao<CityEntity>
    {
        /// <summary>
        /// Recupera le città in una provincia.
        /// </summary>
        /// <param name="acronym">Sigla della provincia.</param>
        Task<IEnumerable<CityEntity>> ReadAllByProvinceAcronymAsync(string acronym);
    }
}

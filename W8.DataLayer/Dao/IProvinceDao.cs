using W8.DataLayer.Entities;

namespace W8.DataLayer.Dao
{
    /// <summary>
    /// DAO per le province.
    /// </summary>
    public interface IProvinceDao : IDao<ProvinceEntity>
    {
        /// <summary>
        /// Elenca le province.
        /// </summary>
        Task<IEnumerable<ProvinceEntity>> ReadAllAsync();
        /// <summary>
        /// Recupera una provincia tramite la sigla.
        /// </summary>
        /// <param name="acronym">La sigla della provincia.</param>
        Task<ProvinceEntity> ReadByAcronymAsync(string acronym);
    }
}

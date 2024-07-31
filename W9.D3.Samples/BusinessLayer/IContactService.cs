using W9.D3.Samples.DataLayer.Entities;

namespace W9.D3.Samples.BusinessLayer
{
    public interface IContactService
    {
        Task AddPersonAsync(string firstName, string lastName);
        Task AddCompanyAsync(string companyName);
        Task UpdatePersonAsync(int personId, string firstName, string lastName);
        Task UpdateCompanyAsync(int companyId, string companyName);
        Task DeleteAsync(int contactId);

        Task<IEnumerable<Contact>> GetAllAsync();
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<IEnumerable<Company>> GetCompaniesAsync();
    }
}

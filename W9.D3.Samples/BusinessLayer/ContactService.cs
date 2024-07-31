using Microsoft.EntityFrameworkCore;
using W9.D3.Samples.DataLayer;
using W9.D3.Samples.DataLayer.Entities;

namespace W9.D3.Samples.BusinessLayer
{
    public class ContactService(ContactsDbContext dbContext) : IContactService
    {
        private readonly ContactsDbContext _dbContext = dbContext;

        public async Task AddCompanyAsync(string companyName) {
            _dbContext.Contacts.Add(new Company { Name = companyName });
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddPersonAsync(string firstName, string lastName) {
            _dbContext.Contacts.Add(new Person { FirstName = firstName, LastName = lastName });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int contactId) {
            var contact = await _dbContext.Contacts.SingleAsync( c=> c.Id == contactId );
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<IEnumerable<Contact>> GetAllAsync() => await _dbContext.Contacts.ToListAsync();

        public async Task<IEnumerable<Company>> GetCompaniesAsync() =>
            await _dbContext.Contacts.OfType<Company>().ToListAsync();

        public async Task<IEnumerable<Person>> GetPeopleAsync() =>
            await _dbContext.Contacts.OfType<Person>().ToListAsync();

        public Task UpdateCompanyAsync(int companyId, string companyName) {
            throw new NotImplementedException();
        }

        public Task UpdatePersonAsync(int personId, string firstName, string lastName) {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Extensions.Logging;
using System.Data;
using W7.D3.BusinessLayer.Data;
using W7.D3.DataLayer;
using W7.D3.DataLayer.Data.Customers;

namespace W7.D3.BusinessLayer.Implementations
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(DbContext dbContext, ILogger<BaseService> logger) : base(dbContext, logger) {
        }

        public IEnumerable<CustomerDto> GetAll() {
            try {
                return dbContext.Customers.ReadAll().Select(c => {
                    if (c is PersonEntity person)
                        return Map(person);
                    else
                        return Map((CompanyEntity)c);
                });
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting all customers");
                throw;
            }
        }

        private static CustomerDto Map(PersonEntity person) {
            return new PersonDto {
                Address = person.Address,
                City = person.City,
                FirstName = person.FirstName,
                FiscalCode = person.FiscalCode,
                LastName = person.LastName,
                PostalCode = person.PostalCode,
                Id = person.Id,
                Region = person.Region,
            };
        }
        private CustomerDto Map(CompanyEntity company) {
            return new CompanyDto {
                Address = company.Address,
                City = company.City,
                Name = company.Name,
                PostalCode = company.PostalCode,
                VatCode = company.VatCode,
                Region = company.Region,
                Id = company.Id
            };
        }

        public CustomerDto GetById(int customerId) {
            try {
                var c = dbContext.Customers.Read(customerId);
                if (c is PersonEntity person)
                    return Map(person);
                else
                    return Map((CompanyEntity)c);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting customer with id = {}", customerId);
                throw;
            }
        }

        public PersonDto RegisterPerson(PersonDto customer) {
            try {
                var person = dbContext.Customers.Create(new PersonEntity {
                    Address = customer.Address,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    FiscalCode = customer.FiscalCode,
                    Region = customer.Region
                });
                return (PersonDto)Map((PersonEntity)person);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering company");
                throw;
            }
        }

        public CompanyDto RegisterCompany(CompanyDto customer) {
            try {
                var company = dbContext.Customers.Create(new CompanyEntity {
                    Address = customer.Address,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    Name = customer.Name,
                    VatCode = customer.VatCode,
                    Region = customer.Region
                });
                return (CompanyDto)Map((CompanyEntity)company);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering person");
                throw;
            }
        }
    }
}

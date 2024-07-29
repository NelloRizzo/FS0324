using Microsoft.Extensions.Logging;
using W8.DataLayer;
using W8.DataLayer.Dao.Exceptions;
using W8.DataLayer.Entities;
using W8.Services.Dto;
using W8.Services.Dto.Utils;
using W8.Services.Exceptions;
using W8.Services.Interfaces;

namespace W8.Services.V1
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(DbContext dbContext, ILogger<BaseService> logger) : base(dbContext, logger) {
        }

        public async Task<CustomerDto> DeleteByIdAsync(int id) {
            try {
                return Map(await _ctx.Customers.DeleteAsync(id));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception deleting customer by id {}", id);
                throw;
            }
        }

        public async Task<CustomerDto> GetByIdAsync(int id) {
            try {
                return Map(await _ctx.Customers.ReadAsync(id));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception getting customer by id {}", id);
                throw;
            }
        }

        /// <summary>
        /// Trasforma un CustomerEntity in CustomerDto.
        /// </summary>
        /// <param name="customer">L'entità da trasformare.</param>
        /// <returns>Il DTO corrispondente.</returns>
        private CustomerDto Map(CustomerEntity customer) =>
            new() {
                City = customer.City,
                Email = customer.Email,
                FirstName = customer.FirstName,
                FiscalCode = customer.FiscalCode,
                LastName = customer.LastName,
                Id = customer.Id,
                Province = customer.Province,
                Mobile = customer.Mobile,
                Phone = customer.Phone,
            };
        public async Task<Page<CustomerDto>> GetPageAsync(int page, int pageSize) {
            try {
                var skip = page * pageSize;
                var content = (await _ctx.Customers.ReadAllAsync(skip, pageSize)).Select(Map);
                return new Page<CustomerDto> {
                    Content = content,
                    PageInfo = new() { PageCount = page, PageSize = pageSize, TotalRecords = await _ctx.Customers.CountAsync() }
                };
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception getting page {} of size {} of customers", page, pageSize);
                throw;
            }
        }

        public async Task<CustomerDto> SaveAsync(CustomerDto dto) {
            try {
                var customer = new CustomerEntity {
                    City = dto.City,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Id = dto.Id,
                    FiscalCode = dto.FiscalCode,
                    Province = dto.Province,
                    Mobile = dto.Mobile,
                    Phone = dto.Phone,
                };
                customer = dto.Id == 0 ? // se l'id non è impostato crea il cliente altrimenti lo aggiorna
                    await _ctx.Customers.CreateAsync(customer) : await _ctx.Customers.UpdateAsync(dto.Id, customer);
                return Map(customer);
            }
            catch (DuplicatedKeyException ex) {
                _logger.LogError(ex, "Duplicated key exception saving customer");
                throw new DataAlreadyPresentException(innerException: ex);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception saving customer");
                throw;
            }
        }
    }
}

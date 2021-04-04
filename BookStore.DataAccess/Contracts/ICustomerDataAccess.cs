using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using BookStore.Domain.Models;

namespace BookStore.DataAccess.Contracts
{
    public interface ICustomerDataAccess
    {
        Task<Customer> InsertAsync(CustomerUpdateModel customer);
        Task<IEnumerable<Customer>> GetAsync();
        Task<Customer> GetAsync(ICustomerIdentity customer);
        Task<Customer> UpdateAsync(CustomerUpdateModel customer);
        Task<Customer> GetByAsync(ICustomerContainer container);
    }
}
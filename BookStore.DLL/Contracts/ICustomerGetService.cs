using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Contracts;

namespace BookStore.BLL.Contracts
{
    public interface ICustomerGetService
    {
        Task<IEnumerable<Customer>> GetAsync();
        Task<Customer> GetAsync(ICustomerIdentity customer);
        Task ValidateAsync(ICustomerContainer container);


    }
}
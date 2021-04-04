using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Contracts
{
    public interface ICustomerUpdateService
    {
        Task<Customer> UpdateAsync(CustomerUpdateModel customer);
    }
}
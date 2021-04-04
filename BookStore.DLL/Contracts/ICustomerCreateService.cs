using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Contracts
{
    public interface ICustomerCreateService
    {
        Task<Customer> CreateAsync(CustomerUpdateModel customer);
    }
}
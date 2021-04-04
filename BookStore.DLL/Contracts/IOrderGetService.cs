using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Contracts;

namespace BookStore.BLL.Contracts
{
    public interface IOrderGetService
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(IOrderIdentity order);
        Task<IEnumerable<Order>> GetByBookAsync(IBookIdentity book);
        Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer);
    }
}
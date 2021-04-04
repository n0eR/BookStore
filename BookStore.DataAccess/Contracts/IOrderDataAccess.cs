using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using BookStore.Domain.Models;

namespace BookStore.DataAccess.Contracts
{
    public interface IOrderDataAccess
    {
        Task<Order> InsertAsync(OrderUpdateModel order);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(IOrderIdentity order);
        Task<Order> UpdateAsync(OrderUpdateModel order);
        Task<IEnumerable<Order>> GetByBookAsync(IBookIdentity book);
        Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer);
    }
}
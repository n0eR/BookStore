using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Contracts
{
    public interface IOrderUpdateService
    {
        public Task<Order> UpdateAsync(OrderUpdateModel order);
    }
}
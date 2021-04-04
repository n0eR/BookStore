using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Contracts
{
    public interface IOrderCreateService
    {
        public Task<Order> CreateAsync(OrderUpdateModel order);
    }
}
using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Implementation
{
    public class OrderUpdateService : IOrderUpdateService
    {
        private IOrderDataAccess OrderDataAccess { get; }
        private IBookGetService BookGetService { get; }
        private ICustomerGetService CustomerGetService { get; }

        public OrderUpdateService(IOrderDataAccess orderDataAccess, IBookGetService bookGetService, ICustomerGetService customerGetService)
        {
            OrderDataAccess = orderDataAccess;
            BookGetService = bookGetService;
            CustomerGetService = customerGetService;
        }

        public async Task<Order> UpdateAsync(OrderUpdateModel order)
        {
            await BookGetService.ValidateAsync(order);
            await CustomerGetService.ValidateAsync(order);

            return await OrderDataAccess.UpdateAsync(order);
        }
    }
}
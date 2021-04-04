using System;
using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Implementation
{
    public class OrderCreateService : IOrderCreateService
    {
        private IOrderDataAccess OrderDataAccess { get; }
        private IBookGetService BookGetService { get; }
        private ICustomerGetService CustomerGetService { get; }

        public OrderCreateService(IOrderDataAccess orderDataAccess, IBookGetService bookGetService, ICustomerGetService customerGetService)
        {
            OrderDataAccess = orderDataAccess;
            BookGetService = bookGetService;
            CustomerGetService = customerGetService;
        }

        public async Task<Order> CreateAsync(OrderUpdateModel order)
        {
            await BookGetService.ValidateAsync(order);
            await CustomerGetService.ValidateAsync(order);

            order.Date = DateTime.Now;
            order.Arrived = false;

            return await OrderDataAccess.InsertAsync(order);
        }
    }
}
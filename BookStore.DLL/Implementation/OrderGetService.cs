using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Contracts;

namespace BookStore.BLL.Implementation
{
    public class OrderGetService : IOrderGetService
    {
        private IOrderDataAccess OrderDataAccess { get; }

        public OrderGetService(IOrderDataAccess orderDataAccess)
        {
            OrderDataAccess = orderDataAccess;
        }

        public Task<IEnumerable<Order>> GetAsync()
        {
            return OrderDataAccess.GetAsync();
        }

        public Task<Order> GetAsync(IOrderIdentity order)
        {
            return OrderDataAccess.GetAsync(order);
        }

        public Task<IEnumerable<Order>> GetByBookAsync(IBookIdentity book)
        {
            return OrderDataAccess.GetByBookAsync(book);
        }

        public Task<IEnumerable<Order>> GetByCustomerAsync(ICustomerIdentity customer)
        {
            return OrderDataAccess.GetByCustomerAsync(customer);
        }
    }
}
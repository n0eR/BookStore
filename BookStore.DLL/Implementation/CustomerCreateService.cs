using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Implementation
{
    public class CustomerCreateService : ICustomerCreateService
    {
        private ICustomerDataAccess CustomerDataAccess { get; }

        public CustomerCreateService(ICustomerDataAccess customerDataAccess)
        {
            CustomerDataAccess = customerDataAccess;
        }

        public Task<Customer> CreateAsync(CustomerUpdateModel customer)
        {
            return CustomerDataAccess.InsertAsync(customer);
        }
    }
}
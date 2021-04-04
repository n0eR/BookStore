using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Implementation
{
    public class CustomerUpdateService : ICustomerUpdateService
    {
        private ICustomerDataAccess CustomerDataAccess { get; }

        public CustomerUpdateService(ICustomerDataAccess customerDataAccess)
        {
            CustomerDataAccess = customerDataAccess;
        }

        public Task<Customer> UpdateAsync(CustomerUpdateModel customer)
        {
            return CustomerDataAccess.UpdateAsync(customer);
        }
    }
}
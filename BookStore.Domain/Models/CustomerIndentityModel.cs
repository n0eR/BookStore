using BookStore.Domain.Contracts;

namespace BookStore.Domain.Models
{
    public class CustomerIndentityModel : ICustomerIdentity
    {
        public int Id { get; }

        public CustomerIndentityModel(int id)
        {
            Id = id;
        }
    }
}
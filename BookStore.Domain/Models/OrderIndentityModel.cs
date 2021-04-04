using BookStore.Domain.Contracts;

namespace BookStore.Domain.Models
{
    public class OrderIndentityModel : IOrderIdentity
    {
        public int Id { get; }

        public OrderIndentityModel(int id)
        {
            Id = id;
        }
    }
}
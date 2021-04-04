using System;
using BookStore.Domain.Contracts;

namespace BookStore.Domain.Models
{
    public class OrderUpdateModel : IOrderIdentity, IBookContainer, ICustomerContainer
    {
        public int Id { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }

        public int BookId { get; set; }

        public int CustomerId { get; set; }
    }
}
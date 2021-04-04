using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Domain.Contracts;

namespace BookStore.Domain
{
    public class Order : IBookContainer, ICustomerContainer
    {
        public int Id { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }

        public Book Book { get; set; }

        public Customer Customer { get; set; }

        public int BookId => Book.Id;

        public int CustomerId => Customer.Id;

    }
}

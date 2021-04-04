using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Addres { get; set; }

        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}

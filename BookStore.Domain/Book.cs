using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

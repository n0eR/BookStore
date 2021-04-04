using System;

namespace BookStore.Client.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }

        public BookDTO Book { get; set; }

        public CustomerDTO Customer { get; set; }

        
    }
}
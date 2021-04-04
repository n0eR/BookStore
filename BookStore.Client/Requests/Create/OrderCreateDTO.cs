using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Client.Requests.Create
{
    public class OrderCreateDTO
    {
        [Required(ErrorMessage = "Book ID is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Customer ID is required")]
        public int CustomerId { get; set; }

        public bool Arrived { get; set; }

        public DateTime Date { get; set; }
    }
}
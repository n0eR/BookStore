using System.ComponentModel.DataAnnotations;

namespace BookStore.Client.Requests.Create
{
    public class BookCreateDTO
    {
        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book author is required")]
        public string Author { get; set; }

        public string Genre { get; set; }

        [Required(ErrorMessage = "Book price is required")]
        public int Price { get; set; }
    }
}
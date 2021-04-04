using BookStore.Domain.Contracts;

namespace BookStore.Domain.Models
{
    public class BookUpdateModel : IBookIdentity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }
    }
}
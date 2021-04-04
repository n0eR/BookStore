using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Implementation
{
    public class BookCreateService : IBookCreateService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookCreateService(IBookDataAccess bookDataAccess)
        {
            BookDataAccess = bookDataAccess;
        }

        public Task<Book> CreateAsync(BookUpdateModel book)
        {
            return BookDataAccess.InsertAsync(book);
        }
    }
}
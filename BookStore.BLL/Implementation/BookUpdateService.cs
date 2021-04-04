using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Implementation
{
    public class BookUpdateService : IBookUpdateService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookUpdateService(IBookDataAccess bookDataAccess)
        {
            BookDataAccess = bookDataAccess;
        }

        public Task<Book> UpdateAsync(BookUpdateModel book)
        {
            return BookDataAccess.UpdateAsync(book);
        }
    }
}
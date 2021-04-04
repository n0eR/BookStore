using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BLL.Contracts;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Contracts;

namespace BookStore.BLL.Implementation
{
    public class BookGetService : IBookGetService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookGetService(IBookDataAccess bookDataAccess)
        {
            BookDataAccess = bookDataAccess;
        }

        public Task<IEnumerable<Book>> GetAsync()
        {
            return BookDataAccess.GetAsync();
        }

        public Task<Book> GetAsync(IBookIdentity book)
        {
            return BookDataAccess.GetAsync(book);
        }

        public async Task ValidateAsync(IBookContainer container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var entity = await BookDataAccess.GetByAsync(container);

            if (entity is null)
            {
                throw new InvalidOperationException($"Book not found by ID {container.BookId}");
            }
        }
    }
}
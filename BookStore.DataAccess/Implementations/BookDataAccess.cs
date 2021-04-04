using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.DataAccess.Context;
using BookStore.DataAccess.Contracts;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Implementations
{
    public class BookDataAccess : IBookDataAccess
    {
        private BookStoreContext Context { get; }
        private IMapper Mapper { get; }

        public BookDataAccess(BookStoreContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }


        public async Task<Book> InsertAsync(BookUpdateModel book)
        {
            var result = await Context.Books.AddAsync(Mapper.Map<Entities.Book>(book));

            await Context.SaveChangesAsync();

            return Mapper.Map<Book>(result.Entity);
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Book>>(await Context.Books.Include(x => x.Orders).ToListAsync());
        }

        public async Task<Book> GetAsync(IBookIdentity book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            return Mapper.Map<Book>(await Context.Books.Include(x => x.Orders).FirstOrDefaultAsync(x => x.Id == book.Id));
        }

        public async Task<Book> UpdateAsync(BookUpdateModel book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var entity = await Context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

            var result = Mapper.Map(book, entity);

            Context.Update(result);

            await Context.SaveChangesAsync();

            return Mapper.Map<Book>(result);
        }

        public async Task<Book> GetByAsync(IBookContainer container)
        {
            return Mapper.Map<Book>(await Context.Books.FirstOrDefaultAsync(x => x.Id == container.BookId));
        }
    }
}
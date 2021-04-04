using System.Collections.Generic;
using System.Linq;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.DataAccess.Contracts
{
    public interface IBookDataAccess
    {
        Task<Book> InsertAsync(BookUpdateModel book);
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(IBookIdentity book);
        Task<Book> UpdateAsync(BookUpdateModel book);
        Task<Book> GetByAsync(IBookContainer container);
    }
}
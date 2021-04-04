using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Contracts;

namespace BookStore.BLL.Contracts
{
    public interface IBookGetService
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(IBookIdentity book);

        Task ValidateAsync(IBookContainer container);
    }
}
using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Contracts
{
    public interface IBookCreateService
    {
        Task<Book> CreateAsync(BookUpdateModel book);
    }
}
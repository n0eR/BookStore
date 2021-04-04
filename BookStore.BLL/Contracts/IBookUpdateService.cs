using System.Threading.Tasks;
using BookStore.Domain;
using BookStore.Domain.Models;

namespace BookStore.BLL.Contracts
{
    public interface IBookUpdateService
    {
        Task<Book> UpdateAsync(BookUpdateModel book);
    }
}
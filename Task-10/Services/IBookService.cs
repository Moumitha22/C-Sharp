using Task_10.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_10.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task CreateBook(Book book);
        Task UpdateBook(int id, Book book);
        Task DeleteBook(int id);
    }
}

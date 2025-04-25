using Task_10.Data;
using Task_10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Task_10.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BookService> _logger;

        public BookService(AppDbContext context, ILogger<BookService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            _logger.LogInformation("Fetching all books from the database.");
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            _logger.LogInformation("Fetching book with ID: {BookId}", id);
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found");
            }
            return book;
        }

        public async Task CreateBook(Book book)
        {
            _logger.LogInformation("Adding new book with Title: {BookTitle}", book.Title);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book added successfully with ID: {BookId}", book.Id);
        }

        public async Task UpdateBook(int id, Book book)
        {       
            _logger.LogInformation("Updating book with ID: {BookId}", id);
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found");
            }
            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book with ID {BookId} updated successfully.", id);
        }

        public async Task DeleteBook(int id)
        {
            _logger.LogInformation("Deleting book with ID: {BookId}", id);
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book with ID {BookId} deleted successfully.", id);
        }
    }
}

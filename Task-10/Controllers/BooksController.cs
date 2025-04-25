using Microsoft.AspNetCore.Mvc;
using Task_10.Models;
using Task_10.Services;

namespace Task_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            _logger.LogInformation("Received request to fetch all books.");
            var books = await _bookService.GetBooks();
            if (books == null || !books.Any())
            {
                _logger.LogWarning("No books found in the database.");
                return NotFound("No books available.");
            }

            _logger.LogInformation("Returning {BookCount} books.", books.Count());
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            _logger.LogInformation("Received request to fetch book with ID: {BookId}", id);

            try
            {
                var book = await _bookService.GetBookById(id);
                return Ok(book);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid data received for adding a book.");
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Received request to add a new book with Title: {BookTitle}", book.Title);
            await _bookService.CreateBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                _logger.LogInformation("Received request to update book with ID: {BookId}", id);
                await _bookService.UpdateBook(id, book);
                return Ok("Book updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation("Received request to delete book with ID: {BookId}", id);
                await _bookService.DeleteBook(id);
                return Ok("Book deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Task_10.Models;

namespace Task_10.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define DbSet for Books (Table)
        public DbSet<Book> Books { get; set; }
    }
}

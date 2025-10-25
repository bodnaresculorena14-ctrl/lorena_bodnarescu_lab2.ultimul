using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Data
{
    public class lorena_bodnarescu_lab2ultimulContext : DbContext
    {
        public lorena_bodnarescu_lab2ultimulContext(DbContextOptions<lorena_bodnarescu_lab2ultimulContext> options)
            : base(options)
        {
        }

        // 🔹 Entitățile principale (tabelele bazei de date)
        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<BookCategory> BookCategory { get; set; } = default!;
    }
}


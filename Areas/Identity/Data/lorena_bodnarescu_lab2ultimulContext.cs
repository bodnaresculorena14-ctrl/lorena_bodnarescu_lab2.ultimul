using lorena_bodnarescu_lab2.ultimul.Models;
using Microsoft.EntityFrameworkCore;

public class lorena_bodnarescu_lab2ultimulContext : DbContext
{
    public lorena_bodnarescu_lab2ultimulContext(DbContextOptions<lorena_bodnarescu_lab2ultimulContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<BookCategory> BookCategory { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Borrowing> Borrowing { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookCategory>()
            .HasKey(bc => new { bc.BookID, bc.CategoryID });
    }
}


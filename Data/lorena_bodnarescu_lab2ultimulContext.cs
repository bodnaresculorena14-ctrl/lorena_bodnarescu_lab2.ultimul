using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Data
{
    public class lorena_bodnarescu_lab2Context : DbContext
    {
        public lorena_bodnarescu_lab2Context(DbContextOptions<lorena_bodnarescu_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<BookCategory> BookCategory { get; set; } = default!;
        public DbSet<Member> Member { get; set; } = default!; // dacă ai creat clasa Member
        public DbSet<Borrowing> Borrowing { get; set; } = default!; // dacă ai creat clasa Borrowing

        // 🔹 Adaugă această metodă
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Definim cheia primară compusă pentru BookCategory
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookID, bc.CategoryID });
        }
    }
}


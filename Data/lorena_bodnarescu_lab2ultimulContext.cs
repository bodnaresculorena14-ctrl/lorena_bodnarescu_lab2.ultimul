using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Data
{
    public class lorena_bodnarescu_lab2ultimulContext : DbContext
    {
        public lorena_bodnarescu_lab2ultimulContext (DbContextOptions<lorena_bodnarescu_lab2ultimulContext> options)
            : base(options)
        {
        }

        public DbSet<lorena_bodnarescu_lab2.ultimul.Models.Book> Book { get; set; } = default!;
        public DbSet<lorena_bodnarescu_lab2.ultimul.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<lorena_bodnarescu_lab2.ultimul.Models.Author> Author { get; set; } = default!;
    }
}

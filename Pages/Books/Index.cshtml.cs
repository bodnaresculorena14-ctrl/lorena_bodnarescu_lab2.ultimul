using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext _context;

        public IndexModel(lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = new List<Book>();


        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
        }


    }
}

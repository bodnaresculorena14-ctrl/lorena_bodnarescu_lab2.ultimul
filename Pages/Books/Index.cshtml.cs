using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2ultimulContext _context;

        public IndexModel(lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Author)
                .ToListAsync();
        }
    }
}

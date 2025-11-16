using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2ultimulContext _context;

        public DetailsModel(lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null) return NotFound();

            return Page();
        }
    }
}

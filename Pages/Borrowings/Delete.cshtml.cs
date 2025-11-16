using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Borrowings
{
    public class DeleteModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2ultimulContext _context;

        public DeleteModel(lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Borrowing = await _context.Borrowing.FindAsync(id);

            if (Borrowing != null)
            {
                _context.Borrowing.Remove(Borrowing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2Context _context;

        public EditModel(lorena_bodnarescu_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
                ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Borrowing.Any(e => e.ID == Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}


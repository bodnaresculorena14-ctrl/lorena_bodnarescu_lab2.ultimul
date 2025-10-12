using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext _context;

        public CreateModel(lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<lorena_bodnarescu_lab2.ultimul.Models.Publisher>(),
                "ID",
                "PublisherName"
            );
            return Page();
        }


        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lorena_bodnarescu_lab2.ultimul.Data;
using lorena_bodnarescu_lab2.ultimul.Models;

namespace lorena_bodnarescu_lab2.ultimul.Pages.Publisher
{
    public class DetailsModel : PageModel
    {
        private readonly lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext _context;

        public DetailsModel(lorena_bodnarescu_lab2.ultimul.Data.lorena_bodnarescu_lab2ultimulContext context)
        {
            _context = context;
        }

        public lorena_bodnarescu_lab2.ultimul.Models.Publisher Publisher { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            else
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.Cafele
{
    public class DeleteModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DeleteModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cafea Cafea { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cafea == null)
            {
                return NotFound();
            }

            var cafea = await _context.Cafea.FirstOrDefaultAsync(m => m.ID == id);

            if (cafea == null)
            {
                return NotFound();
            }
            else 
            {
                Cafea = cafea;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cafea == null)
            {
                return NotFound();
            }
            var cafea = await _context.Cafea.FindAsync(id);

            if (cafea != null)
            {
                Cafea = cafea;
                _context.Cafea.Remove(Cafea);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

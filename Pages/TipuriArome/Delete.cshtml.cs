using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriArome
{
    public class DeleteModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DeleteModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipAroma TipAroma { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipAroma == null)
            {
                return NotFound();
            }

            var tiparoma = await _context.TipAroma.FirstOrDefaultAsync(m => m.ID == id);

            if (tiparoma == null)
            {
                return NotFound();
            }
            else 
            {
                TipAroma = tiparoma;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipAroma == null)
            {
                return NotFound();
            }
            var tiparoma = await _context.TipAroma.FindAsync(id);

            if (tiparoma != null)
            {
                TipAroma = tiparoma;
                _context.TipAroma.Remove(TipAroma);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

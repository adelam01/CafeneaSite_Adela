using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CafeneaSite.Pages.TipuriLapte
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DeleteModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipLapte TipLapte { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipLapte == null)
            {
                return NotFound();
            }

            var tiplapte = await _context.TipLapte.FirstOrDefaultAsync(m => m.ID == id);

            if (tiplapte == null)
            {
                return NotFound();
            }
            else 
            {
                TipLapte = tiplapte;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipLapte == null)
            {
                return NotFound();
            }
            var tiplapte = await _context.TipLapte.FindAsync(id);

            if (tiplapte != null)
            {
                TipLapte = tiplapte;
                _context.TipLapte.Remove(TipLapte);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

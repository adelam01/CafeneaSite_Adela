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

namespace CafeneaSite.Pages.Cafele
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
      public Cafea Cafea { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cafea == null)
            {
                return NotFound();
            }

            var cafea = await _context.Cafea
                .Include(c => c.TipCafea)
                .Include(c => c.TipBoabe)
                .Include(c => c.TipLapte)
                .Include(c => c.TipAroma)
                .FirstOrDefaultAsync(m => m.ID == id);

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

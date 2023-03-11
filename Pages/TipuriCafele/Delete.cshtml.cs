using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriCafele
{
    public class DeleteModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DeleteModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipCafea TipCafea { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipCafea == null)
            {
                return NotFound();
            }

            var tipcafea = await _context.TipCafea.FirstOrDefaultAsync(m => m.ID == id);

            if (tipcafea == null)
            {
                return NotFound();
            }
            else 
            {
                TipCafea = tipcafea;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipCafea == null)
            {
                return NotFound();
            }
            var tipcafea = await _context.TipCafea.FindAsync(id);

            if (tipcafea != null)
            {
                TipCafea = tipcafea;
                _context.TipCafea.Remove(TipCafea);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

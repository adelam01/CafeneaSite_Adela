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

namespace CafeneaSite.Pages.TipuriToppinguri
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
      public TipTopping TipTopping { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipTopping == null)
            {
                return NotFound();
            }

            var tiptopping = await _context.TipTopping.FirstOrDefaultAsync(m => m.ID == id);

            if (tiptopping == null)
            {
                return NotFound();
            }
            else 
            {
                TipTopping = tiptopping;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipTopping == null)
            {
                return NotFound();
            }
            var tiptopping = await _context.TipTopping.FindAsync(id);

            if (tiptopping != null)
            {
                TipTopping = tiptopping;
                _context.TipTopping.Remove(TipTopping);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

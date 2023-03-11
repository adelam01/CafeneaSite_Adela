using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriLapte
{
    public class DetailsModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DetailsModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

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
    }
}

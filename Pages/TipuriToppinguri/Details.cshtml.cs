using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriToppinguri
{
    public class DetailsModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DetailsModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

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
    }
}

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

namespace CafeneaSite.Pages.TipuriArome
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DetailsModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

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
    }
}

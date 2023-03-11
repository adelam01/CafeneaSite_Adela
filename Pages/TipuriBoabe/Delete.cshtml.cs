using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriBoabe
{
    public class DeleteModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public DeleteModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipBoabe TipBoabe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipBoabe == null)
            {
                return NotFound();
            }

            var tipboabe = await _context.TipBoabe.FirstOrDefaultAsync(m => m.ID == id);

            if (tipboabe == null)
            {
                return NotFound();
            }
            else 
            {
                TipBoabe = tipboabe;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipBoabe == null)
            {
                return NotFound();
            }
            var tipboabe = await _context.TipBoabe.FindAsync(id);

            if (tipboabe != null)
            {
                TipBoabe = tipboabe;
                _context.TipBoabe.Remove(TipBoabe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

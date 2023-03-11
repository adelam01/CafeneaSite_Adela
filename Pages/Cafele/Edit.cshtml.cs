using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.Cafele
{
    public class EditModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public EditModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cafea Cafea { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cafea == null)
            {
                return NotFound();
            }

            var cafea =  await _context.Cafea.FirstOrDefaultAsync(m => m.ID == id);
            if (cafea == null)
            {
                return NotFound();
            }
            Cafea = cafea;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cafea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeaExists(Cafea.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CafeaExists(int id)
        {
          return _context.Cafea.Any(e => e.ID == id);
        }
    }
}

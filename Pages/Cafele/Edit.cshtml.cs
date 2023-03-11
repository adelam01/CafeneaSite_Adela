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
            if (id == null)
            {
                return NotFound();
            }

            Cafea = await _context.Cafea
                .Include(b => b.TipCafea)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Cafea == null)
            {
                return NotFound();
            }

            // POPULARE VIEW DATA - TIP CAFEA
            var listaTipCafea = _context.TipCafea.Select(x => new
            {
                x.ID,
                x.Tip
            });
            ViewData["TipCafeaID"] = new SelectList(listaTipCafea, "ID", "Tip");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeaActualizare = await _context.Cafea
                .Include(i => i.TipCafea)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (cafeaActualizare == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Cafea>(
            cafeaActualizare,
            "Cafea",
            i => i.DenumireCafea, i => i.TipCafeaID,
            i => i.Pret))
            {
                //cafeaActualizare(_context, cafeaActualizare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }
    }
}

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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CafeneaSite.Pages.Cafele
{
    [Authorize(Roles = "Admin")]

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
                .Include(b => b.TipBoabe)
                .Include(b => b.TipLapte)
                .Include(b => b.TipAroma)
                .Include(b => b.TipTopping)
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

            // POPULARE VIEW DATA - TIP CAFEA
            var listaTipBoabe = _context.TipBoabe.Select(x => new
            {
                x.ID,
                x.DenumireBoabe
            });
            ViewData["TipBoabeID"] = new SelectList(listaTipBoabe, "ID", "DenumireBoabe");

            // POPULARE VIEW DATA - TIP CAFEA
            var listaTipLapte = _context.TipLapte.Select(x => new
            {
                x.ID,
                x.DenumireLapte
            });
            ViewData["TipLapteID"] = new SelectList(listaTipLapte, "ID", "DenumireLapte");

            // POPULARE VIEW DATA - TIP CAFEA
            var listaTipAroma = _context.TipAroma.Select(x => new
            {
                x.ID,
                x.DenumireAroma
            });
            ViewData["TipAromaID"] = new SelectList(listaTipAroma, "ID", "DenumireAroma");

            // POPULARE VIEW DATA - TIP TOPPING
            var listaTipTopping = _context.TipTopping.Select(x => new
            {
                x.ID,
                x.DenumireTopping
            });
            ViewData["TipToppingID"] = new SelectList(listaTipTopping, "ID", "DenumireTopping");

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
                .Include(i => i.TipBoabe)
                .Include(i => i.TipLapte) 
                .Include(i => i.TipAroma)
                .Include(i => i.TipTopping)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (cafeaActualizare == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Cafea>(
            cafeaActualizare,
            "Cafea",
            i => i.DenumireCafea, i => i.TipCafeaID, i => i.TipBoabeID,
            i => i.TipLapteID, i => i.TipAromaID, i => i.TipToppingID, i => i.Pret))
            {
                //cafeaActualizare(_context, cafeaActualizare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CafeneaSite.Data;
using CafeneaSite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace CafeneaSite.Pages.Cafele
{
    public class CreateModel : CafeaTipuriToppingPageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public CreateModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // POPULARE VIEWDATA - TIP CAFEA
            var listaTipCafea = _context.TipCafea.Select(x => new
            {
                x.ID,
                x.Tip,
                x.Imagine
            });
            ViewData["TipCafeaID"] = new SelectList(listaTipCafea, "ID", "Tip", "Imagine");

            // POPULARE VIEWDATA - TIP BOABE
            var listaTipBoabe = _context.TipBoabe.Select(x => new
            {
                x.ID,
                x.DenumireBoabe
            });
            ViewData["TipBoabeID"] = new SelectList(listaTipBoabe, "ID", "DenumireBoabe");

            // POPULARE VIEWDATA - TIP LAPTE
            var listaTipLapte = _context.TipLapte.Select(x => new
            {
                x.ID,
                x.DenumireLapte
            });
            ViewData["TipLapteID"] = new SelectList(listaTipLapte, "ID", "DenumireLapte");

            // POPULARE VIEWDATA - TIP AROMA
            var listaTipAroma = _context.TipAroma.Select(x => new
            {
                x.ID,
                x.DenumireAroma
            });
            ViewData["TipAromaID"] = new SelectList(listaTipAroma, "ID", "DenumireAroma");

            // POPULARE VIEWDATA - TIP TOPPING
            var listaTipTopping = _context.TipTopping.Select(x => new
            {
                x.ID,
                x.DenumireTopping
            });
            ViewData["TipToppingID"] = new SelectList(listaTipTopping, "ID", "DenumireTopping");

            var cafea = new Cafea();
            cafea.CafeaTipuriTopping = new List<CafeaTipuriTopping>();
            PopulateToppingAtribuitCafeleiData(_context, cafea);


            return Page();
        }

        [BindProperty]
        public Cafea Cafea { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedToppings)
        {
            var newCafea = new Cafea();
            if (selectedToppings != null)
            {
                newCafea.CafeaTipuriTopping = new List<CafeaTipuriTopping>();
                foreach (var cat in selectedToppings)
                {
                    var catToAdd = new CafeaTipuriTopping
                    {
                        TipToppingID = int.Parse(cat)
                    };
                    newCafea.CafeaTipuriTopping.Add(catToAdd);
                }
            }

            Cafea.CafeaTipuriTopping = newCafea.CafeaTipuriTopping;
            _context.Cafea.Add(Cafea);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        
        PopulateToppingAtribuitCafeleiData(_context, newCafea);
        return Page();
    }
}
    }

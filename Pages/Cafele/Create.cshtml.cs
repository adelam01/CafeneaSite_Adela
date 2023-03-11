﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.Cafele
{
    public class CreateModel : PageModel
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
                x.Tip
            });
            ViewData["TipCafeaID"] = new SelectList(listaTipCafea, "ID", "Tip");

            // POPULARE VIEWDATA - TIP CAFEA
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

            return Page();
        }

        [BindProperty]
        public Cafea Cafea { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Cafea.Add(Cafea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

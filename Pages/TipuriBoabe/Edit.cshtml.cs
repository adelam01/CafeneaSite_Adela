﻿using System;
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

namespace CafeneaSite.Pages.TipuriBoabe
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
        public TipBoabe TipBoabe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipBoabe == null)
            {
                return NotFound();
            }

            var tipboabe =  await _context.TipBoabe.FirstOrDefaultAsync(m => m.ID == id);
            if (tipboabe == null)
            {
                return NotFound();
            }
            TipBoabe = tipboabe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // PENTRU IMAGINE -> transformam imaginea intr-un string de tipul base64-encoded
            byte[] bytes = null;
            if (TipBoabe.BoabeImg != null)
            {
                using (Stream fisier = TipBoabe.BoabeImg.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fisier))
                    {
                        bytes = br.ReadBytes((Int32)fisier.Length);
                    }

                }
                TipBoabe.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TipBoabe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipBoabeExists(TipBoabe.ID))
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

        private bool TipBoabeExists(int id)
        {
          return _context.TipBoabe.Any(e => e.ID == id);
        }
    }
}

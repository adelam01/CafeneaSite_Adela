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

namespace CafeneaSite.Pages.TipuriLapte
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public CreateModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TipLapte TipLapte { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // PENTRU IMAGINE -> transformam imaginea intr-un string de tipul base64-encoded
            byte[] bytes = null;
            if (TipLapte.LapteImg != null)
            {
                using (Stream fisier = TipLapte.LapteImg.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fisier))
                    {
                        bytes = br.ReadBytes((Int32)fisier.Length);
                    }

                }
                TipLapte.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TipLapte.Add(TipLapte);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

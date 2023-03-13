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

namespace CafeneaSite.Pages.TipuriArome
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
        public TipAroma TipAroma { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TipAroma.Add(TipAroma);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

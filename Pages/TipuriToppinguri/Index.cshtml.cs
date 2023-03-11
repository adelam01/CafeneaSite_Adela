using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriToppinguri
{
    public class IndexModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public IndexModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        public IList<TipTopping> TipTopping { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TipTopping != null)
            {
                TipTopping = await _context.TipTopping.ToListAsync();
            }
        }
    }
}

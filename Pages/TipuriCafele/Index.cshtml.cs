using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.TipuriCafele
{
    public class IndexModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public IndexModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        public IList<TipCafea> TipCafea { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TipCafea != null)
            {
                TipCafea = await _context.TipCafea.ToListAsync();
            }
        }
    }
}

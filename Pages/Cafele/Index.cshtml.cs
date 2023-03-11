using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;

namespace CafeneaSite.Pages.Cafele
{
    public class IndexModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public IndexModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        public IList<Cafea> Cafea { get; set; } = default!;
        public CafeaData CafeaD { get; set; }
        public int CafeaID { get; set; }

        // PENTRU CAUTARE - SEARCH STRING
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, string searchString)
        {
            CafeaD = new CafeaData();
            CurrentFilter = searchString;

            CafeaD.Cafele = await _context.Cafea
                .Include(b => b.TipCafea)
                .Include(b => b.TipBoabe)
                .Include(b => b.TipLapte)
                .Include(b => b.TipAroma)
                .Include(b => b.TipTopping)
                .ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                CafeaD.Cafele = CafeaD.Cafele.Where(s => s.TipCafea.Tip.Contains(searchString)

               || s.TipBoabe.DenumireBoabe.Contains(searchString)
               || s.TipLapte.DenumireLapte.Contains(searchString)
               || s.TipAroma.DenumireAroma.Contains(searchString)
               || s.TipTopping.DenumireTopping.Contains(searchString)
               || s.DenumireCafea.Contains(searchString));
            }

            if (id != null)
            {
                CafeaID = id.Value;
                Cafea Serviciu = CafeaD.Cafele
                .Where(i => i.ID == id.Value).Single();
            }


            }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Data;
using CafeneaSite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CafeneaSite.Pages.TipuriLapte
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public IndexModel(CafeneaSite.Data.CafeneaSiteContext context)
        {
            _context = context;
        }

        public IList<TipLapte> TipLapte { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TipLapte != null)
            {
                TipLapte = await _context.TipLapte.ToListAsync();
            }
        }
    }
}

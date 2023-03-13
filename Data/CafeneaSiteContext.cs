using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CafeneaSite.Models;

namespace CafeneaSite.Data
{
    public class CafeneaSiteContext : DbContext
    {
        public CafeneaSiteContext (DbContextOptions<CafeneaSiteContext> options)
            : base(options)
        {
        }

        public DbSet<CafeneaSite.Models.Cafea> Cafea { get; set; } = default!;

        public DbSet<CafeneaSite.Models.TipCafea> TipCafea { get; set; }

        public DbSet<CafeneaSite.Models.TipBoabe> TipBoabe { get; set; }

        public DbSet<CafeneaSite.Models.TipLapte> TipLapte { get; set; }

        public DbSet<CafeneaSite.Models.TipAroma> TipAroma { get; set; }

        public DbSet<CafeneaSite.Models.TipTopping> TipTopping { get; set; }

        public DbSet<CafeneaSite.Models.Membru> Membru { get; set; }
    }
}

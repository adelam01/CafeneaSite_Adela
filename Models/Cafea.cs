using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class Cafea
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Cafea")]
        public string DenumireCafea { get; set; }

        //Cheie straina si navigation propery pentru TipCafea
        public int TipCafeaID { get; set; }
        [Display(Name = "Tip Cafea")]
        public TipCafea TipCafea { get; set; }


        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

    }
}

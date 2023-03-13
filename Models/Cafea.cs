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
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea cafelei trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        public string DenumireCafea { get; set; }

        //Cheie straina si navigation propery pentru TipCafea
        public int? TipCafeaID { get; set; }
        [Display(Name = "Tip Cafea")]
        public TipCafea? TipCafea { get; set; }

        //Cheie straina si navigation propery pentru TipBoabe
        public int? TipBoabeID { get; set; }
        [Display(Name = "Tip Boabe")]
        public TipBoabe? TipBoabe { get; set; }

        //Cheie straina si navigation propery pentru Lapte
        public int? TipLapteID { get; set; }
        [Display(Name = "Tip Lapte")]
        public TipLapte? TipLapte { get; set; }

        //Cheie straina si navigation propery pentru Arome
        public int? TipAromaID { get; set; }
        [Display(Name = "Tip Aroma")]
        public TipAroma? TipAroma { get; set; }

        //Navigation propery pentru Topping
        public ICollection<CafeaTipuriTopping>? CafeaTipuriTopping { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

    }
}

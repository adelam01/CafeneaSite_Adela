using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;


namespace CafeneaSite.Models
{
    public class TipTopping
    {
        public int ID { get; set; }

        [Display(Name = "Tip Topping")]
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea topping-ului trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        [StringLength(70, MinimumLength = 3)]
        public string DenumireTopping { get; set; }

        //pentru imagine
        public string? Imagine { get; set; }

        [Display(Name = "Imagine")]
        [NotMapped]
        public IFormFile ToppingImg { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<CafeaTipuriTopping>? CafeaTipuriTopping { get; set; }
    }
}

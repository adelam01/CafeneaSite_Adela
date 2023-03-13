using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class TipBoabe
    {
        public int ID { get; set; }

        [Display(Name = "Tip Boabe")]
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea boabelor trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        [StringLength(70, MinimumLength = 3)]
        public string DenumireBoabe { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class TipTopping
    {
        public int ID { get; set; }

        [Display(Name = "Tip Topping")]
        public string DenumireTopping { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}

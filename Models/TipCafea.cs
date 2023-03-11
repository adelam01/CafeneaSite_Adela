using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class TipCafea
    {
        public int ID { get; set; }

        [Display(Name = "Tip cafea")]
        public string Tip { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}

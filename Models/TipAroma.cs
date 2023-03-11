using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class TipAroma
    {
        public int ID { get; set; }

        [Display(Name = "Tip Aroma")]
        public string DenumireAroma { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}

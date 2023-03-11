using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class TipLapte
    {
        public int ID { get; set; }

        [Display(Name = "Tip Lapte")]
        public string DenumireLapte { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CafeneaSite.Models
{
    public class TipBoabe
    {
        public int ID { get; set; }

        [Display(Name = "Tip Boabe")]
        public string DenumireBoabe { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}

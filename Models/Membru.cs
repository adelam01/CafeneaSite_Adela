using System.ComponentModel.DataAnnotations;
//using System.Xml.Linq;    auzi da fa si crud

namespace CafeneaSite.Models
{
    public class Membru
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }

        [Display(Name = "Nume Complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
    }
}


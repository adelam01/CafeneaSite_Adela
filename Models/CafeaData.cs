namespace CafeneaSite.Models
{
    public class CafeaData
    {
        public IEnumerable<Cafea> Cafele { get; set; }
        public IEnumerable<TipTopping> TipTopping { get; set; }
        public IEnumerable<CafeaTipuriTopping> CafeaTipuriTopping { get; set; }
    }
}

namespace CafeneaSite.Models
{ 
    public class CafeaTipuriTopping
    {
        public int ID { get; set; }

        // Cheie straina pt cafea
        public int CafeaID { get; set; }
        public Cafea Cafea { get; set; }

        // Cheie straina pentru Tip Topping
        public int TipToppingID { get; set; }
        public TipTopping TipTopping { get; set; }
    }
}

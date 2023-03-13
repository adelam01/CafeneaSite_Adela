using Microsoft.AspNetCore.Mvc.RazorPages;
using CafeneaSite.Data;

namespace CafeneaSite.Models
{
    public class CafeaTipuriToppingPageModel : PageModel
    {
        public List<ToppingAtribuitCafeleiData> AtribuireToppingDataList;
        public void PopulateToppingAtribuitCafeleiData(CafeneaSiteContext context, Cafea cafea)
        {
            var allToppings = context.TipTopping;
            var cafeaTopping = new HashSet<int>(
            cafea.CafeaTipuriTopping.Select(c => c.TipToppingID)); //
            AtribuireToppingDataList = new List<ToppingAtribuitCafeleiData>();
            foreach (var cat in allToppings)
            {
                AtribuireToppingDataList.Add(new ToppingAtribuitCafeleiData
                {
                    TipToppingID = cat.ID,
                    Denumire = cat.DenumireTopping,
                    Atribuire = cafeaTopping.Contains(cat.ID)
                });
            }
        }
        public void UpdateCafeaTipuriTopping(CafeneaSiteContext context, string[] selectedToppings, Cafea cafeaToUpdate)
        {
            if (selectedToppings == null)
            {
                cafeaToUpdate.CafeaTipuriTopping = new List<CafeaTipuriTopping>();
                return;
            }
            var selectedToppingsHS = new HashSet<string>(selectedToppings);
            var CafeaTipuriTopping = new HashSet<int>
            (cafeaToUpdate.CafeaTipuriTopping.Select(c => c.TipTopping.ID));
            foreach (var cat in context.TipTopping)
            {
                if (selectedToppingsHS.Contains(cat.ID.ToString()))
                {
                    if (!CafeaTipuriTopping.Contains(cat.ID))
                    {
                        cafeaToUpdate.CafeaTipuriTopping.Add(
                        new CafeaTipuriTopping
                        {
                            CafeaID = cafeaToUpdate.ID,
                            TipToppingID = cat.ID
                        });
                    }
                }
                else
                {
                    if (CafeaTipuriTopping.Contains(cat.ID))
                    {
                        CafeaTipuriTopping courseToRemove = cafeaToUpdate
                        .CafeaTipuriTopping
                        .SingleOrDefault(i => i.TipToppingID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

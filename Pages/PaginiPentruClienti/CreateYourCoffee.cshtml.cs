using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CafeneaSite.Pages
{
    public class CreateYourCoffeeModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./CodQR");
        }
    }
}

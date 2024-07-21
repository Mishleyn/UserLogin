using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLogin.Models;

namespace UserLogin.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        ApplicationContext context;

        [BindProperty]
        public User Person { get; set; } = new();

        Random random = new Random();

        public CreateModel(ApplicationContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Person.ConfirmationCode = random.Next(1000, 10000);    
            context.Users.Add(Person);
            await context.SaveChangesAsync();
            return RedirectToPage("ConfirmRegister", new {name = Person.Name, confirmationCode = Person.ConfirmationCode});
        }
    }
}

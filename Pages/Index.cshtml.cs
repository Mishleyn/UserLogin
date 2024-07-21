using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;

        public List<User> Users { get; private set; } = new();

        public IndexModel(ApplicationContext db)
        {
            context = db;
        }

        public void OnGet()
        {
            Users = context.Users.AsNoTracking().ToList();
        }
    }
}

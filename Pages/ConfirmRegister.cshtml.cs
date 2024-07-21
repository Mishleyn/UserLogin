using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLogin.Models;

namespace UserLogin.Pages
{
    public class ConfirmRegisterModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public string Name { get; set; } = "";

        [BindProperty]
        public long ConfirmationCode { get; set; }

        public ConfirmRegisterModel(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void OnGet(string name, long confirmationCode)
        {
            Name = $"Name: {name}";
            _contextAccessor.HttpContext.Session.SetString("ConfirmationCode", confirmationCode.ToString());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            long validConfirmationCode = long.Parse(_contextAccessor.HttpContext.Session.GetString("ConfirmationCode"));

            if(ConfirmationCode == validConfirmationCode)
            {
                return RedirectToPage("ResultPage", new {message = "Успешно"});
            }

            return RedirectToPage("ResultPage", new {message = "Неверный код подтверждения"});
        }
    }
}

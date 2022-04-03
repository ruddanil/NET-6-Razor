using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Account
{
    public class SimpleLoginModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager; // ��������� � ���������� UserManager
        public string errorMassage;
        public void OnGet()
        {

        }
        public IActionResult OnPost(string login, string password)
        {
            if (userManager.checkPasswordSimple(login, password))
            {
                return RedirectToPage("Welcome");
            }
            else
            {
                errorMassage = "�������� ����� ��� ������";
                return Page();
            }
        }
    }
}

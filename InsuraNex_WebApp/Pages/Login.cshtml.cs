using InsuraNex.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InsuraNex.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]

        public Login LoginViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
            ViewData["Notification"] = new Notification
            {
                Type = Enums.NotificationType.Info,
                Message = "Please enter your credentials to Login"
            };
        }

        public async Task<IActionResult> OnPost(string? ReturnUrl)
        {
            if(ModelState.IsValid) 
            {
                var signInResult = await signInManager.PasswordSignInAsync(
                LoginViewModel.Username, LoginViewModel.Password, false, false);
                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToPage(ReturnUrl);
                    }
                    return RedirectToPage("LandingPage");
                }
                else
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = Enums.NotificationType.Error,
                        Message = "Unable to login"
                    };

                    return Page();
                }
            }
            
            return Page();
        }
    }
}

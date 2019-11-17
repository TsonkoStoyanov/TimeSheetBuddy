namespace TimeSheetBuddy.Web.Areas.Identity.Pages.Account
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using TimeSheetBuddy.Data.Models;


    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<TimeSheetBuddyUser> signInManager;

        public LogoutModel(SignInManager<TimeSheetBuddyUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await signInManager.SignOutAsync();

            return Redirect("/");
        }
    }

}

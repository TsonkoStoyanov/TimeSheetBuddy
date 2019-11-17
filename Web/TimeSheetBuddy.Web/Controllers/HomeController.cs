namespace TimeSheetBuddy.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TimeSheetBuddy.Web.Models;


    public class HomeController : BaseController
    {
        public HomeController()
        {

        }

        public async Task<IActionResult> Index()
        {
             return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

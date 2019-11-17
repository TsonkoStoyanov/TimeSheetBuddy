namespace TimeSheetBuddy.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Services;
    using TimeSheetBuddy.Web.InputModels;

    public class ManagerController : AdminController
    {
        private readonly IManagerService managerService;

        public ManagerController(IManagerService managerService)
        {
            this.managerService = managerService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManagerInputModel managerInputModel)

        {
            if (!ModelState.IsValid)
            {
                return View(managerInputModel);
            }

            await managerService.Create(managerInputModel);

            return Redirect("/Home/Index");
        }
    }
}
namespace TimeSheetBuddy.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Services;
    using TimeSheetBuddy.Web.InputModels;

    public class EmployeeController : AdminController
    {
        private readonly IEmployeeService employeeSerice;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeSerice = employeeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeInputModel employeeInputModel)

        {
            if (!ModelState.IsValid)
            {
                return View(employeeInputModel);
            }

            await employeeSerice.Create(employeeInputModel);

            return Redirect("/Home/Index");
        }
    }
}
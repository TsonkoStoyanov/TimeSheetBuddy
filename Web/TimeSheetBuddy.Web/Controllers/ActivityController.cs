namespace TimeSheetBuddy.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Services;
    using TimeSheetBuddy.Web.InputModels;

    public class ActivityController : Controller
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActivityInputModel activityInputModel)

        {
            if (!ModelState.IsValid)
            {
                return View(activityInputModel);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            activityInputModel.EmployeeId = userId;

            await activityService.Create(activityInputModel);

            return Redirect("/Home/Index");
        }
    }
}
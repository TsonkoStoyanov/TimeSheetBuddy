namespace TimeSheetBuddy.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Common;
    using TimeSheetBuddy.Services;
    using TimeSheetBuddy.Web.InputModels;

    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectInputModel projectInputModel)

        {
            if (!ModelState.IsValid)
            {
                return View(projectInputModel);
            }

            await projectService.Create(projectInputModel);

            return Redirect("/Home/Index");
        }
    }
}
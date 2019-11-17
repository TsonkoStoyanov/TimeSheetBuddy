namespace TimeSheetBuddy.Services
{
    using System.Threading.Tasks;
    using TimeSheetBuddy.Data.Models;
    using TimeSheetBuddy.Data;
    using TimeSheetBuddy.Web.InputModels;


    public class ProjectService : IProjectService
    {
      
        private readonly TimeSheetBuddyDbContext context;

        public ProjectService(TimeSheetBuddyDbContext context)
        {            
            this.context = context;
        }

        public async Task<bool> Create(ProjectInputModel projectInputModel)
        {
            var project = new Project 
            {
                Name = projectInputModel.Name,
                Discription = projectInputModel.Description
            };            

            context.Projects.Add(project);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}

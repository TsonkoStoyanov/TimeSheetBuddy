namespace TimeSheetBuddy.Services
{
    using System;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Data.Models;
    using TimeSheetBuddy.Data;
    using TimeSheetBuddy.Web.InputModels;
    using Microsoft.EntityFrameworkCore;

    public class ActivityService : IActivityService
    {
      
        private readonly TimeSheetBuddyDbContext context;

        public ActivityService(TimeSheetBuddyDbContext context)
        {            
            this.context = context;
                    }

        public async Task<bool> Create(ActivityInputModel activityInputModel)
        {
            var employee = await context.Employees
                .FirstOrDefaultAsync(x => x.TimeSheetBuddyUserId == activityInputModel.EmployeeId);
            
            if (employee==null)
            {
                throw new ArgumentException("No such user");
            }
            
            var activity = new Activity 
            {
                Date = DateTime.UtcNow,
                ActivityDesc = activityInputModel.ActivityDesc,
                TimeWorked = activityInputModel.TimeWorked,
                Employee = employee
            };            

            context.Activities.Add(activity);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}

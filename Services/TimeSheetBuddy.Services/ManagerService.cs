namespace TimeSheetBuddy.Services
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Common;
    using TimeSheetBuddy.Data;
    using TimeSheetBuddy.Data.Models;
    using TimeSheetBuddy.Web.InputModels;


    public class ManagerService : IManagerService
    {

        private readonly UserManager<TimeSheetBuddyUser> userManager;
        private readonly TimeSheetBuddyDbContext context;

        public ManagerService(TimeSheetBuddyDbContext context, UserManager<TimeSheetBuddyUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<bool> Create(ManagerInputModel managerInputModel)
        {
            var user = new TimeSheetBuddyUser
            {
                UserName = managerInputModel.Email,
                Email = managerInputModel.Email,
                FirstName = managerInputModel.FirstName,
                LastName=managerInputModel.LastName,
                PhoneNumber = managerInputModel.PhoneNumber               
            };

            var userCreateResult = await userManager.CreateAsync(user, managerInputModel.Password);

            if (userCreateResult.Succeeded)
            {
                user.EmailConfirmed = true;

                await userManager.AddToRoleAsync(user, GlobalConstants.ManagerRoleName);
            }


            int result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}

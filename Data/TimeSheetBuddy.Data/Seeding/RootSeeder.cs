namespace TimeSheetBuddy.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Common;
    using TimeSheetBuddy.Data.Models;

    internal class RootSeeder : ISeeder
    {
        public async Task SeedAsync(TimeSheetBuddyDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<TimeSheetBuddyUser>>();

            if (!userManager.Users.Any())
            {
                var user = new TimeSheetBuddyUser
                {
                    UserName = GlobalConstants.AdminUserName,
                    Email = GlobalConstants.AdminEmail,
                    EmailConfirmed = true
                };

                var password = "123456";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }

            }
        }
    }
}
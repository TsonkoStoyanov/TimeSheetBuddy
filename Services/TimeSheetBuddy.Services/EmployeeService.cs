namespace TimeSheetBuddy.Services
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using TimeSheetBuddy.Common;
    using TimeSheetBuddy.Data.Models;
    using TimeSheetBuddy.Data;
    using TimeSheetBuddy.Web.InputModels;


    public class EmployeeService : IEmployeeService
    {

        private readonly UserManager<TimeSheetBuddyUser> userManager;
        private readonly TimeSheetBuddyDbContext context;

        public EmployeeService(TimeSheetBuddyDbContext context, UserManager<TimeSheetBuddyUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<bool> Create(EmployeeInputModel employeeInputModel)
        {
            var user = new TimeSheetBuddyUser
            {
                UserName = employeeInputModel.Email,
                Email = employeeInputModel.Email,
                FirstName = employeeInputModel.FirstName,
                LastName = employeeInputModel.LastName
            };

            var userCreateResult = await userManager.CreateAsync(user, employeeInputModel.Password);

            if (userCreateResult.Succeeded)
            {
                user.EmailConfirmed = true;

                await userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
            }

            Employee employee = new Employee
            {
                Email = employeeInputModel.Email,
                FirstName = employeeInputModel.FirstName,
                LastName = employeeInputModel.LastName,
                PhoneNumber = employeeInputModel.PhoneNumber,
                TimeSheetBuddyUserId = user.Id

            };

            context.Employees.Add(employee);

            int result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}

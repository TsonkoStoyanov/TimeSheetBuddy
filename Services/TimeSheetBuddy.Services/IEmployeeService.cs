namespace TimeSheetBuddy.Services
{
    using System.Threading.Tasks;
    using TimeSheetBuddy.Web.InputModels;


    public interface IEmployeeService
    {
        Task<bool> Create(EmployeeInputModel employeeInputModel);
    }
}

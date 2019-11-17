namespace TimeSheetBuddy.Services
{
    using System.Threading.Tasks;
    using TimeSheetBuddy.Web.InputModels;


    public interface IManagerService
    {
        Task<bool> Create(ManagerInputModel managerInputModel);
    }
}

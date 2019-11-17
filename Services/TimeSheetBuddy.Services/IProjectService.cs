namespace TimeSheetBuddy.Services
{
    using System.Threading.Tasks;
    using TimeSheetBuddy.Web.InputModels;


    public interface IProjectService
    {
        Task<bool> Create(ProjectInputModel projectInputModel);
    }
}

namespace TimeSheetBuddy.Services
{
    using System.Threading.Tasks;
    using TimeSheetBuddy.Web.InputModels;


    public interface IActivityService
    {
        Task<bool> Create(ActivityInputModel activityInputModel);
    }
}

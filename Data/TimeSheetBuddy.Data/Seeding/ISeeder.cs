namespace TimeSheetBuddy.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(TimeSheetBuddyDbContext dbContext, IServiceProvider serviceProvider);
    }
}

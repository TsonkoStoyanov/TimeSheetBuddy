namespace TimeSheetBuddy.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class TimeSheetBuddyUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

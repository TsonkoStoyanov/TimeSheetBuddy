namespace TimeSheetBuddy.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            Projects = new HashSet<Project>();
            Id = Guid.NewGuid().ToString();
        }
       
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
       
        public string TimeSheetBuddyUserId { get; set; }
        public virtual TimeSheetBuddyUser UserEmployee { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}

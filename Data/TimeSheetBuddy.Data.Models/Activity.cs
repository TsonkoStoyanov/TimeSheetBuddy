namespace TimeSheetBuddy.Data.Models
{

    using System;


    public class Activity
    {
        public Activity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string ActivityDesc { get; set; }

        public int TimeWorked { get; set; }

        public string ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}

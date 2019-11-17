namespace TimeSheetBuddy.Data.Models
{
    using System;


    public class Project
    {
        public Project()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }


    }
}

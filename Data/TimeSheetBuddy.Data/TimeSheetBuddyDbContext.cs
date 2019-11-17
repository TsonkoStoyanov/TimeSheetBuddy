namespace TimeSheetBuddy.Data
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using TimeSheetBuddy.Data.Models;

    public class TimeSheetBuddyDbContext : IdentityDbContext<TimeSheetBuddyUser, IdentityRole, string>
    {
        public TimeSheetBuddyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Employee> Employees { get; set; }        
    }
}

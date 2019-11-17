
namespace TimeSheetBuddy.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;


    public class ActivityInputModel
    {

        [Required]
        public string ActivityDesc { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "Can only be between 1 .. 8")]
        public int TimeWorked { get; set; }

        public string EmployeeId { get; set; }
    }
}

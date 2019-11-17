namespace TimeSheetBuddy.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;


    public class ProjectInputModel
    {
        [Required]       
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 10)]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SchoolsProject.Models.DTOs
{
    public class createSchoolDto
    {
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "Please select School's Name")]
        [Display(Name = "School Name")]
        [MaxLength(40)]
        public string? SchoolName { get; set; }
        [Required]
        public string? RegionName { get; set; }
        [Required]
        public string? GovernorateName { get; set; }
        
    }
}

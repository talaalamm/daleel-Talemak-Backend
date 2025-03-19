using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolsProject.Models
{
    public class School
    {
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "Please select School's Name")]
        [Display(Name = "School Name")]
        public string? SchoolName { get; set; }


        [Display(Name = "School Image")]
        public string? SchoolImage { get; set; }

        
        //FK
        public int RegionId { get; set; }
        public Region Region { get; set; }

       




    }
}

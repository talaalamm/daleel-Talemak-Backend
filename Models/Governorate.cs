using System.ComponentModel.DataAnnotations;

namespace SchoolsProject.Models
{
    public class Governorate
    {
        [Display(Name = "Governorate Id")]
        public int GovernorateId { get; set; }

        [Required(ErrorMessage = "Please select Governorate's Name")]
        [Display(Name = "Governorate Name")]
        public string? GovernorateName { get; set; }
       
    }
}

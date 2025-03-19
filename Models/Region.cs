using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolsProject.Models
{
    public class Region
    {
        [Display(Name = "Region Id")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Please select Region's Name")]
        [Display(Name = "Region Name")]
        public string? RegionName { get; set; }


        //FK
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
      


    }
}

using System.ComponentModel.DataAnnotations;

namespace SchoolsProject.Models
{
    public class StarRating
    {
        public int StarRatingId { get; set; }
        [Display(Name = " Rate the school ")]
        public int Rating { get; set; } // Rating value ( 1-5 stars)

       //FK
        public int SchoolId { get; set; }
    }
}

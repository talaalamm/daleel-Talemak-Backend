using System.ComponentModel.DataAnnotations;

namespace SchoolsProject.Models
{
    public class SchoolComment
    {
        [Display(Name = "School's Comments Id")]
        public int SchoolCommentId { get; set; }
        [Required(ErrorMessage = "Fill Comment's Body")]
        [Display(Name = "Comment's Body")]
        [MaxLength(500)]
        public string? CommentBody { get; set; }
        //FK
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}

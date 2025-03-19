using Microsoft.EntityFrameworkCore;
using SchoolsProject.Models;

namespace SchoolsProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {  }

        public DbSet<School> Schools { get; set; }  
        public DbSet<Governorate> Governorates { get; set; }  
        public DbSet<Region> Regions { get; set; }
        public DbSet<SchoolComment> SchoolComments { get; set; }
        public DbSet<StarRating> StarRatings { get; set; }


    }
}

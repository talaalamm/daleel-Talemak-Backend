using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolsProject.Data;
using SchoolsProject.Models;

namespace SchoolsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarRatingController(AppDbContext db) : ControllerBase
    {
        // Endpoint to add a rating
        [HttpPost("addRating")]
        public async Task<IActionResult> PostRating( StarRating rating)
        {
            if (rating.Rating < 1 || rating.Rating > 5)
            {
                return BadRequest("Rating must be between 1 and 5.");
            }

            db.StarRatings.Add(rating);
            await db.SaveChangesAsync();
            return Ok(new { Message = "Rating added successfully." });
        }

        // Endpoint to get the average rating for an item
        [HttpGet("AverageRating/{schoolid}")]
        public async Task<IActionResult> GetAverageRating(int schoolid)
        {
            var ratings = await db.StarRatings
                .Where(r => r.SchoolId == schoolid)
                .ToListAsync();

            if (!ratings.Any())
            {
                return NotFound("No ratings found for this item.");
            }

            var averageRating = ratings.Average(r => r.Rating);
            // Round to the nearest integer
            double roundedRating = Math.Round(averageRating * 2) / 2;
            return Ok(new { SchoolId= schoolid, AverageRating = roundedRating });
        }
    }

}


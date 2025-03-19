using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolsProject.Data;
using SchoolsProject.Models;
using SchoolsProject.Models.DTOs;

namespace SchoolsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolCommentsController(AppDbContext db) : ControllerBase
    {
        //Get all Comments
        [HttpGet("GetSchoolComment/{schoolid:int}")]
        public async Task<IActionResult> GetSchoolComment(int schoolid)
        {
            var schoolcomments = await db.SchoolComments.Where(x => x.SchoolId == schoolid)
                .Include(x => x.School)
                .Select(x => x.CommentBody)
                .ToListAsync();
            return Ok(schoolcomments);
        }

        //Return total Comments
        [HttpGet("GetTotalComments/{schoolid:int}")]
        public async Task<IActionResult> GetTotalComments(int schoolid)
        {
            var totalComments = await db.SchoolComments.CountAsync(x => x.SchoolId == schoolid);

            return Ok(totalComments);

        }
        //Create Comment
        [HttpPost("CreateSchoolComment/{schoolid:int}")]
        public async Task<IActionResult> PostSchoolComments(int schoolid, CreateCommentDto commentdto)
        {
            var school = await db.Schools.FindAsync(schoolid);
            if (school == null)
            {
                return NotFound("School not found.");
            }
            if (ModelState.IsValid)
            {

                SchoolComment schoolComment = new SchoolComment()
                {
                    SchoolId = schoolid,
                    CommentBody = commentdto.CommentBody
                   
                };
                
                try
                {
                    db.SchoolComments.Add(schoolComment);
                    await db.SaveChangesAsync();
                    return CreatedAtAction(nameof(PostSchoolComments), schoolComment);  
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Conflict("Concurrency conflict occurred while saving the comment.");
                }

            }
            return BadRequest();
        }
       
    }
}

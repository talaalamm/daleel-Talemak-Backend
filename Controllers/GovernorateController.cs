using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolsProject.Data;

namespace SchoolsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController(AppDbContext db) : ControllerBase
    {
        //Endpoint for Cascading drop down list
        //Endpoint to Get all Governarate
        [HttpGet("GetGovernarate")]
        public async Task<IActionResult> GetGovernarate()
        {
            var governarates = await db.Governorates.ToListAsync();
            return Ok(governarates);
        }
    }
}

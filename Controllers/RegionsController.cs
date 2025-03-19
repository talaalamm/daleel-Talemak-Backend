using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolsProject.Data;

namespace SchoolsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(AppDbContext db) : ControllerBase
    {
        //Endpoint for Cascading drop down list
        // Endpoint to fetch Regions based on selected Governarate
        [HttpGet("GetRegions/{GovernorateId}")]
        public async Task<IActionResult> GetRegionsBasedOnGovernarate(int GovernorateId)
        {
            if (!await db.Governorates.AnyAsync(g => g.GovernorateId == GovernorateId))
            {
                return NotFound($"Governorate with ID {GovernorateId} not found.");
            }
            var regions = await db.Regions.Where(x => x.GovernorateId == GovernorateId).ToListAsync();
            if (!regions.Any())
            {
                return NotFound("No regions found for the specified governorate.");
            }
            return Ok(regions);
        }
        
    }
}

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
    public class SchoolsController(AppDbContext db) : ControllerBase
    {

        //Get all Schools
        [HttpGet("GetSchool")]
        public async Task<IActionResult> GetSchool()
        {
            var schools = await db.Schools.Include(x => x.Region).ThenInclude(y => y.Governorate).ToListAsync();
            return Ok(schools);
        }
        //Get school by id

        [HttpGet("GetSchool/{id:int}")]
        public async Task<IActionResult> GetSchool(int id)
        {
            var school =await db.Schools.Where(x=>x.SchoolId==id).Include(y => y.Region)
                .ThenInclude(y => y.Governorate).FirstOrDefaultAsync();
            return Ok(school);
        }
            
        //Create School
        [HttpPost("CreateSchool")]
        public async Task<IActionResult> PostSchool(createSchoolDto model)
        {
                
                if (model == null || string.IsNullOrEmpty(model.SchoolName) || string.IsNullOrEmpty(model.GovernorateName) || string.IsNullOrEmpty(model.RegionName))
                {
                    return BadRequest("Please provide all required fields: School Name, Governorate, and Region.");
                }
            var existingSchool = await db.Schools
                .FirstOrDefaultAsync(s => s.SchoolName == model.SchoolName);
            if (existingSchool != null)
            {
                return BadRequest("A school with this name already exists.");
            }

            var governorate = await db.Governorates
                    .FirstOrDefaultAsync(g => g.GovernorateName==model.GovernorateName);
                if (governorate == null)
                {
                    return NotFound("Governorate not found.");
                }

                var region = await db.Regions
                    .FirstOrDefaultAsync(r => r.RegionName==model.RegionName );
                if (region == null)
                {
                    return NotFound("Region not found .");
                }
  


                var school = new School
                {
                    SchoolName = model.SchoolName,
                    RegionId = region.RegionId // Foreign key to the region
                    
                };
            try
            {
               db.Schools.Add(school);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(PostSchool), school);
            }

            catch (Exception ex)
            {
                // Catch any unexpected errors and return a 500 Internal Server Error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

           

        }

        //Search by school's name
        [HttpGet("search/{schoolname?}")]
        public async Task<IActionResult> SearchByName(string schoolname)
        {
            
            var data =await db.Schools.Where(x => x.SchoolName!.Contains(schoolname))
                .Include(y=>y.Region)
                .ToListAsync();

            if (!data.Any())
            {
                return NotFound("No schools found matching the provided name.");
            }

            return Ok(data);
        }


        //search by school's region
        [HttpGet("searchbyregionandgovernorate/{governorateName?}/{regionName?}")]
        public async Task<IActionResult> SearchByRegionAndGovernorate(string governorateName, string regionName )
        {
            if (string.IsNullOrEmpty(regionName) || string.IsNullOrEmpty(governorateName))
            {
                return BadRequest("Both region name and governorate name are required.");
            }

            // Find the region with the given name and governorate
            var region = await db.Regions
                .Include(r => r.Governorate)
                .FirstOrDefaultAsync(r => r.RegionName == regionName && r.Governorate.GovernorateName == governorateName);

            if (region == null)
            {
                return NotFound("Region with the specified governorate not found.");
            }

            // Find schools associated with the specific region
            var schools = await db.Schools
                .Where(s => s.RegionId == region.RegionId)
                .Include(s => s.Region)
                .ToListAsync();

            if (!schools.Any())
            {
                return NotFound("No schools found in the selected region and governorate.");
            }

            return Ok(schools);
        }

        // [HttpGet("searchbyregion/{regionName?}")]    
        //public async Task<IActionResult> SearchByRegion(string regionName)
        //{

        //    if (string.IsNullOrEmpty(regionName))
        //    {
        //        return BadRequest("Region name is required.");
        //    }
        //    var region =await  db.Regions.
        //        Where(r=>r.RegionName== regionName).Include(x=>x.Governorate).FirstOrDefaultAsync();

        //    if (region == null)
        //    {
        //        return NotFound("Region not found.");
        //    }

        //    var data = await db.Schools
        //        .Where(x => x.RegionId == region.RegionId) 
        //        .Include(y => y.Region)
        //        .ToListAsync();

        //    if (!data.Any())
        //    {
        //        return NotFound("No schools found in the selected region.");
        //    }

        //    return Ok(data);
        //}

        //search by school's Governorate
        [HttpGet("searchbygovernorate/{governoratename?}")]
        public async Task<IActionResult> SearchByGovernorate(string governoratename)
        {

            if (string.IsNullOrEmpty(governoratename))
            {
                return BadRequest("Governorate name is required.");
            }
            var governorate = await db.Governorates.
                Where(r => r.GovernorateName == governoratename).FirstOrDefaultAsync();
            
            if (governorate == null)
            {
                return NotFound("Region not found.");
            }
            
            var data = await db.Schools
                .Where(x => x.Region.GovernorateId == governorate.GovernorateId)
                .Include(y => y.Region)
                .ToListAsync();

            if (!data.Any())
            {
                return NotFound("No schools found in the selected governorate.");
            }

            return Ok(data);
        }

        
        


           

         


        }

    }


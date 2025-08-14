using System.Threading.Tasks;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Area.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class BrandsController : ControllerBase
    {
        private readonly IBrandservice brandService;

        public BrandsController(IBrandservice brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(brandService.GetAll(false));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var brand = brandService.GetById(id);
            if (brand is null) return NotFound();
            return Ok(brand);

        }


        [HttpPost("")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] BrandRequest request)
        {
            var newId = await brandService.CreateFile(request);

          
            return CreatedAtAction(
                nameof(Get),
                new { area = "Admin", id = newId }, 
                null
            );
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var updated = brandService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = brandService.ToggleStatus(id);
            return updated ? Ok(new { message = "status toggled" }) : NotFound(new { message = "brand not found" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = brandService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }
    }
}

using KASHOP.BLL.Services.Interfaces;
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
    }
}

using KASHOP.BLL.Services.Classes;
using KASHOP.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Area.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles ="Customer")]
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
            return Ok(brandService.GetAll(true));
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

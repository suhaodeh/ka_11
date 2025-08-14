using System.Security.Claims;
using KASHOP.BLL.Services.Classes;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Area.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }


        [HttpPost("create")]
        public async Task <IActionResult> Create([FromForm] ProductRequest request)
        {

            var result = await _productService.CreateFile(request);

            return Ok(result);

        }
    }
}

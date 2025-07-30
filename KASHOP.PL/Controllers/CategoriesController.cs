using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService _categoryService)
        {
            this._categoryService = _categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id )
        {
            var category = _categoryService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);

        }

        [HttpPost("")]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = _categoryService.Create(request);
            return CreatedAtAction(nameof(Get), new { id },new {message=request });
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var updated = _categoryService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id  )
        {
            var updated = _categoryService.ToggleStatus(id);
            return updated ? Ok(new { message = "status toggled" }) : NotFound(new { message = "category not found" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            var deleted = _categoryService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }

    }
}

using KASHOP.BLL.Services;
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
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id )
        {
            var category = categoryService.GetCategoryById(id);
            if (category is null) return NotFound();
            return Ok(category);

        }

        [HttpPost("")]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = categoryService.CreateCategory(request);
            return CreatedAtAction(nameof(Get), new { id });
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var updated = categoryService.UpdateCategory(id, request);
            return updated > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id  )
        {
            var updated = categoryService.ToggleStatus(id);
            return updated ? Ok(new { message = "status toggled" }) : NotFound(new { message = "category not found" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            var deleted = categoryService.DeleteCategory(id);
            return deleted > 0 ? Ok() : NotFound();
        }

    }
}

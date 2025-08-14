﻿using KASHOP.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Area.Customer
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
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
        public IActionResult Get([FromRoute] int id)
        {
            var category = _categoryService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);

        }
    }
}

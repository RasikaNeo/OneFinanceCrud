using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;
using OneFinanceCrud.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneFinanceCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository ,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

      
        [HttpGet]
        public async Task<ActionResult<Category>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cat = _mapper.Map<Category>(category);
            var newCategory = await _categoryRepository.AddCategoryAsync(cat);

            //return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);

            if (newCategory == null) {
                return BadRequest();
            }
            else
            {
                 
                return Ok(newCategory);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);
            if (updatedCategory == null)
            {
                return NotFound();
            }

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var result = await _categoryRepository.DeleteCategoryAsync(category);
            if (!result)
            {
                return StatusCode(500, "Failed to delete the category.");
            }

            return Ok();
        }
    }
}
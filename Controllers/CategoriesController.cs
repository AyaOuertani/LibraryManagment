using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Interface;
using LibraryManagment.DTO.Category;
using LibraryManagment.Services;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync() {
            var result = await _categoriesService.GetAllCategoriesAsync();
            return Ok(result);
        }
        [HttpGet("categoryName/{categoryName}")]
        public async Task<IActionResult> GetCategoryByNameeAsync(string categoryName)
        {
            var categoryDTO = new CategoryDTO { CategoryName = categoryName };
            var result = await _categoriesService.GetCategoryByNameeAsync(categoryDTO);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var result = await _categoriesService.AddCategoryAsync(categoryDTO);
            return Ok(result);
        }

        [HttpDelete("categoryDeleteName/{categoryDeleteName}")]
        public async Task<IActionResult> DeleteCategoryAsync(string categoryDeleteName)
        {
            var categoryDTO = new CategoryDTO { CategoryName = categoryDeleteName };
            await _categoriesService.DeleteCategoryAsync(categoryDTO);
            return Ok();
        }
    }
}

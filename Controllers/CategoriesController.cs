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
        public async Task<IActionResult> GetAllAsync() {
            var result = await _categoriesService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetByNameeAsync(string Name)
        {
            var result = await _categoriesService.GetByNameeAsync(Name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Category categoryDTO)
        {
            var result = await _categoriesService.AddAsync(categoryDTO);
            return Ok(result);
        }

        [HttpDelete("Delete/{Delete}")]
        public async Task<IActionResult> DeleteCategoryAsync(string categoryDeleteName)
        {
            var result =await _categoriesService.DeleteAsync(categoryDeleteName);
            return Ok(result);
        }
    }
}

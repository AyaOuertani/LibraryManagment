using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Interface;
using LibraryManagment.DTOs.CategoryDTOs;
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
        public async Task<IActionResult> AddAsync(Category category)
        {
            var result = await _categoriesService.AddAsync(category);
            return Ok(result);
        }

        [HttpDelete("DeleteName/{DeleteName}")]
        public async Task<IActionResult> DeleteCategoryAsync(string DeleteName)
        {
            var result =await _categoriesService.DeleteAsync(DeleteName);
            return Ok(result);
        }
    }
}

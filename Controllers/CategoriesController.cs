using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Interface;
using LibraryManagment.Services;
using LibraryManagment.DTOs.CategoriesDTOs.Request;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Categories
    public class CategoriesController : ControllerBase
    {
        #region Variables+Constructor 
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService) => _categoriesService = categoriesService;
        #endregion
        #region Get 
        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()=> Ok(await _categoriesService.GetAllAsync());
        #endregion
        #region ByName
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetByNameeAsync(string Name) => Ok(await _categoriesService.GetByNameeAsync(Name));
        #endregion
        #endregion
        #region Post/Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryRequest category) => Ok(await _categoriesService.AddAsync(category));
        #endregion
        #region Delete
        [HttpDelete("DeleteName/{DeleteName}")]
        public async Task<IActionResult> DeleteCategoryAsync(string DeleteName) => Ok(await _categoriesService.DeleteAsync(DeleteName));
        #endregion
    }
    #endregion
}

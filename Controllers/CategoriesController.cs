using LibraryManagment.DTOs.CategoriesDTOs;
using LibraryManagment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Categories
    public class CategoriesController : ControllerBase
    {
        #region Variables + Constructor 
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService) => _categoriesService = categoriesService;
        #endregion

        #region Get 
        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize) => Ok(await _categoriesService.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ByName
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetByNameeAsync(string Name) => Ok(await _categoriesService.GetByNameeAsync(Name));
        #endregion
        #endregion

        #region Post/Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryRequest category)
        {
            return (await _categoriesService.AddAsync(category)).Add ? Ok("Added Successfully!") : NotFound("Failed To Add");
        }
        #endregion

        #region Delete
        [HttpDelete("DeleteName/{DeleteName}")]
        public async Task<IActionResult> DeleteCategoryAsync(string DeleteName)
        {
            return (await _categoriesService.DeleteAsync(DeleteName)).Delete ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion
    }
    #endregion
}

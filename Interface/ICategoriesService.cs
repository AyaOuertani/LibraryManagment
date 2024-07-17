using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.DTO.Category;
using LibraryManagment.DTOs.Categories;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<GetAllCategoriesResponse>> GetAllCategoriesAsync();

        public Task<CategoryDTO> GetCategoryByNameeAsync(CategoryDTO categoryByNameeDTO);

        public Task<string> AddCategoryAsync(CategoryDTO categoryDTO);

        public Task DeleteCategoryAsync(CategoryDTO categoryDTO);
    }

}

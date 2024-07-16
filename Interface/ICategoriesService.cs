using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.DTO.Category;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public List<Category> GetAllCategories();

        public Task<CategoryDTO> GetCategoryByNameeAsync(CategoryDTO categoryByNameeDTO);

        public Task<string> AddCategoryAsync(CategoryDTO categoryDTO);

        public Task DeleteCategoryAsync(CategoryDTO categoryDTO);
    }

}

using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.DTOs.Categories;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync();

        public Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName);

        public Task<string> AddAsync(DTO.Category.Category category);

        public Task<string> DeleteAsync(string categoryName);
    }

}

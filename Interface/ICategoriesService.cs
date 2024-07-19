using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.DTOs.CategoriesDTOs.Responses;
using LibraryManagment.DTOs.CategoriesDTOs.Request;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync();

        public Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName);

        public Task<string> AddAsync(AddCategoryRequest category);

        public Task<string> DeleteAsync(string categoryName);
    }

}

using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.DTOs.CategoryDTOs;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync();

        public Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName);

        public Task<string> AddAsync(DTOs.CategoryDTOs.Category category);

        public Task<string> DeleteAsync(string categoryName);
    }

}

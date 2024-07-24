using LibraryManagment.DTOs.CategoriesDTOs;
using LibraryManagment.Models;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<PaginatedList<GetAllCategoriesResponse>> GetAllAsync(int pageNumber , int pageSize);

        public Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName);

        public Task<AddCategoryResponse> AddAsync(AddCategoryRequest category);

        public Task<bool> DeleteAsync(string categoryName);
    }

}

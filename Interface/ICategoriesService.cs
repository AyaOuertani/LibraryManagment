using LibraryManagment.DTOs.CategoriesDTOs.Request;
using LibraryManagment.DTOs.CategoriesDTOs.Responses;

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

using LibraryManagment.DTOs.CategoriesDTOs;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync(int pageNumber , int pageSize);

        public Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName);

        public Task<bool> AddAsync(AddCategoryRequest category);

        public Task<bool> DeleteAsync(string categoryName);
    }

}

using LibraryManagment.DTOs.CategoriesDTOs;

namespace LibraryManagment.Interface
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync(int pageNumber , int pageSize);

        public Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName);

        public Task<AddCategoryResponse> AddAsync(AddCategoryRequest category);

        public Task<DeleteCategoryResponse> DeleteAsync(string categoryName);
    }

}

using LibraryManagment.Data;
using LibraryManagment.DTO.Books.Requests;
using LibraryManagment.DTO.Category;
using LibraryManagment.DTOs.Categories;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDBcontext _dbcontext;
        public CategoriesService(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<GetAllCategoriesResponse>> GetAllCategoriesAsync() {
            var categories = await _dbcontext.Categories.Include(book => book.Books).Select(categorySelected => new GetAllCategoriesResponse
            {
                CategoryName = categorySelected.CategoryName,
                BooksTitle = categorySelected.Books.Select(bookSelected => bookSelected.Title).ToList()
            }).ToListAsync();

            return categories;
        }
         public async Task<CategoryDTO> GetCategoryByNameeAsync(CategoryDTO categoryByNameeDTO)
        {
            var category = await _dbcontext.Categories.Include(book => book.Books).FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryByNameeDTO.CategoryName.ToUpper());
            if (category is null)
             {
                 throw new KeyNotFoundException("Not Found");
             }
            return new CategoryDTO
            {
                CategoryName = category.CategoryName
             };
        }

        public async Task<string> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var addcategory = new Category()
            {
                CategoryName=categoryDTO.CategoryName,
            };

            _dbcontext.Categories.Add(addcategory);
            await _dbcontext.SaveChangesAsync();

            return "Category Added Successfully!";
        }

        public async Task DeleteCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryDTO.CategoryName.ToUpper());
            if (category is null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _dbcontext.Categories.Remove(category);
            await _dbcontext.SaveChangesAsync();
        }
    }
}

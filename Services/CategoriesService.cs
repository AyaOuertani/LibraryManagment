using LibraryManagment.Data;
using LibraryManagment.DTOs.BooksDTOs.Requests;
using LibraryManagment.DTOs.CategoryDTOs;
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
        public async Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync() {
            var categories = await _dbcontext.Categories.Include(book => book.Books).Select(categorySelected => new GetAllCategoriesResponse
            {
                CategoryName = categorySelected.CategoryName,
                BooksTitle = categorySelected.Books.Select(bookSelected => bookSelected.Title).ToList()
            }).ToListAsync();

            return categories;
        }
         public async Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName)
        {
            var category = await _dbcontext.Categories.Include(book => book.Books).FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryName.ToUpper());
            if (category is null)
             {
                 throw new KeyNotFoundException("Not Found");
             }
            return new GetAllCategoriesResponse
            {
                CategoryName = category.CategoryName,
                BooksTitle = category.Books.Select(bookSelected => bookSelected.Title).ToList(),
            };

        }

        public async Task<string> AddAsync(DTOs.CategoryDTOs.Category category)
        {
            var addcategory = new Models.Category()
            {
                CategoryName= category.CategoryName,
            };

            _dbcontext.Categories.Add(addcategory);
            await _dbcontext.SaveChangesAsync();

            return "Category Added Successfully!";
        }

        public async Task<string> DeleteAsync(string categoryName)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryName.ToUpper());
            if (category is null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _dbcontext.Categories.Remove(category);
            await _dbcontext.SaveChangesAsync();
            return ("Deleted Successfully");
        }
    }
}

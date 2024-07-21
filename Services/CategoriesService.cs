using LibraryManagment.Data;
using LibraryManagment.DTOs.CategoriesDTOs.Request;
using LibraryManagment.DTOs.CategoriesDTOs.Responses;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{
    public class CategoriesService : ICategoriesService
    {
        #region Variable+Constroctor
        private readonly ApplicationDBcontext _dbcontext;
        public CategoriesService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion
        #region Get
        #region All
        public async Task<IEnumerable<GetAllCategoriesResponse>> GetAllAsync()
        {
            List<GetAllCategoriesResponse> categories = await _dbcontext.Categories.Include(book => book.Books)
                                                                                   .Select(categorySelected => new GetAllCategoriesResponse( categorySelected.CategoryName, 
                                                                                                                                             categorySelected.Books.Select(bookSelected => bookSelected.Title).ToList())).ToListAsync();

            return categories;
        }
        #endregion
        #region ByName
        public async Task<GetAllCategoriesResponse> GetByNameeAsync(string categoryName)
        {
            Category? category = await _dbcontext.Categories.Include(book => book.Books)
                                                            .FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryName.ToUpper()) ?? throw new KeyNotFoundException("Not Found");
            return new GetAllCategoriesResponse( category.CategoryName, 
                                                 category.Books.Select(bookSelected => bookSelected.Title).ToList());

        }
        #endregion
        #endregion
        #region Add
        public async Task<string> AddAsync(AddCategoryRequest category)
        {
            _dbcontext.Categories.Add(new Category(category.CategoryName));
            await _dbcontext.SaveChangesAsync();
            return "Category Added Successfully!";
        }
        #endregion
        #region Delete
        public async Task<string> DeleteAsync(string categoryName)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryName.ToUpper()) 
                                                      ?? throw new KeyNotFoundException("Not Found");
            _dbcontext.Categories.Remove(category);
            await _dbcontext.SaveChangesAsync();
            return ("Deleted Successfully");
        }
        #endregion
    }
}

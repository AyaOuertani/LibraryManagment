using LibraryManagment.Data;
using LibraryManagment.DTOs.BooksDTOs;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagment.Services
{
    public class BooksService : IBooksService
    {
        #region Variables + Constroctor
        private readonly ApplicationDBcontext _dbcontext;
        public BooksService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region All
        public async Task<IEnumerable<GetAllBooksResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _dbcontext.Books.Include(b => b.BookCategory)
                                         .Skip((pageNumber - 1) * pageSize)
                                         .Take(pageSize)
                                         .Select(b => new GetAllBooksResponse(b.Title,
                                                                              b.Author,
                                                                              b.Stock,
                                                                              b.BookCategory.CategoryName)).ToListAsync();
        }
        #endregion

        #region ById
        public async Task<GetBookByIdResponse> GetByIdAsync(int id)
        {
            Books? book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory)
                                                .FirstOrDefaultAsync(bookSelected => bookSelected.ID == id);
            return book is null
                ? throw new KeyNotFoundException("Not Found")
                : new GetBookByIdResponse(book.Title,
                                          book.Author,
                                          book.Stock,
                                          book.BookCategory.CategoryName);
        }
        #endregion

        #region ByTitle
        public async Task<GetBookByTitleResponse> GetByTitleAsync(string title)
        {
            Books? book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory)
                                                .FirstOrDefaultAsync(bookSelected => bookSelected.Title.ToUpper() == title.ToUpper());
            return book is null
                ? throw new KeyNotFoundException("Not Found")
                : new GetBookByTitleResponse(book.Author,
                                             book.Stock,
                                             book.BookCategory.CategoryName);
        }
        #endregion

        #region ByCategory
        public async Task<IEnumerable<GetBooksByCategoryResponse>> GetByCategoryAsync(string categoryName)
        {
            Category category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryName.ToUpper())
                                                            ?? throw new KeyNotFoundException("Not Found");
            IEnumerable<Books> books = await _dbcontext.Books.Where(bookSelected => bookSelected.BookCategory.CategoryID == category.CategoryID).ToListAsync();
            return books.Select(b => new GetBooksByCategoryResponse(b.Title,
                                                                    b.Author,
                                                                    b.Stock)).ToList();
        }
        #endregion

        #region ByAuther
        public async Task<IEnumerable<GetBooksByAuthorResponse>> GetByAuthorAsync(string auther)
        {
            List<Books> book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory)
                                                     .Where(bookSelected => bookSelected.Author.ToUpper() == auther.ToUpper()).ToListAsync();
            return book.Count == 0
                ? throw new KeyNotFoundException("Not Found")
                : (IEnumerable<GetBooksByAuthorResponse>)book.Select(b => new GetBooksByAuthorResponse(b.Title,
                                                                                                       b.Stock,
                                                                                                       b.BookCategory.CategoryName)).ToList();
        }
        #endregion

        #endregion

        #region Update
        public async Task<UpdateBooksResponse> UpdateAsync(UpdateBooksRequest bookRequest)
        {
            Books book = _dbcontext.Books.FirstOrDefault(bookSelected => bookSelected.Title.ToUpper() == bookRequest.Title.ToUpper())
                                         ?? throw new KeyNotFoundException("Not Found");
            if (bookRequest.Stock.HasValue)
            {
                book.Stock = bookRequest.Stock.Value;
            }
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                return new UpdateBooksResponse(false);
            }
            return new UpdateBooksResponse();
        }
        #endregion

        #region Add
        public async Task<AddBookResponse> AddAsync(AddBookRequest bookRequest)
        {
            Category category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == bookRequest.BookCategory.CategoryName.ToUpper())
                                                           ?? throw new KeyNotFoundException("Category not found");
            try
            {
                _dbcontext.Books.Add(new Books
                {
                    Title = bookRequest.Title,
                    Author = bookRequest.Author,
                    Stock = bookRequest.Stock,
                    BookCategory = category
                });
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                return new AddBookResponse(false);
            }
            return new AddBookResponse();
        }
        #endregion

        #region Delete
        public async Task<DeleteBookResponse> DeleteAsync(string bookName)
        {
            Books book = await _dbcontext.Books.FirstOrDefaultAsync(BookSelected => BookSelected.Title.ToUpper() == bookName.ToUpper())
                                               ?? throw new KeyNotFoundException("Not Found");
            try
            {
                _dbcontext.Books.Remove(book);
                await _dbcontext.SaveChangesAsync();
            }
            catch { return new DeleteBookResponse(false); }
            return new DeleteBookResponse();
        }
        #endregion
    }

}

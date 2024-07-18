using LibraryManagment.Data;
using LibraryManagment.DTOs.BooksDTOs.Requests;
using LibraryManagment.DTOs.BooksDTOs.Responses;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
namespace LibraryManagment.Services
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDBcontext _dbcontext;
        public BooksService(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<GetAllBooksResponses>> GetAllAsync()
        {
            var books = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).Select(bookSelected => new GetAllBooksResponses
            {
                Title = bookSelected.Title,
                Author = bookSelected.Author,
                Stock = bookSelected.Stock,
                BookCategory = bookSelected.BookCategory.CategoryName
            }).ToListAsync();

            return books;
        }
        public async Task<GetBookByIdResponse> GetByIdAsync(int id)
        {
            var book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).FirstOrDefaultAsync(bookSelected => bookSelected.ID == id);
            if (book is null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new GetBookByIdResponse
            {
                Title = book.Title,
                Author = book.Author,
                Stock = book.Stock,
                BookCategory = book.BookCategory.CategoryName,
            };

        }

        public async Task<GetBookByTitleResponse> GetByTitleAsync (string title)
        {
            var book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).FirstOrDefaultAsync(bookSelected => bookSelected.Title.ToUpper() == title.ToUpper());
            if (book is null){
                throw new KeyNotFoundException("Not Found");
            }
            return new GetBookByTitleResponse {
                Author = book.Author,
                Stock= book.Stock,
                BookCategory= book.BookCategory.CategoryName,
            };
        }

        public async Task<IEnumerable<GetBookByCategoryResponse>> GetByCategoryAsync(string categoryName)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == categoryName.ToUpper() );
            if (category == null)
            {
                throw new KeyNotFoundException("Not Found"); 
            }
            var books =  await _dbcontext.Books.Where(bookSelected => bookSelected.BookCategory.CategoryID == category.CategoryID).ToListAsync();
            return books.Select(bookSelected => new GetBookByCategoryResponse
            {
                Title = bookSelected.Title,
                Author = bookSelected.Author,
                Stock = bookSelected.Stock
            }).ToList();
        }

        public async Task<IEnumerable<GetBookByAuthorResponse>> GetByAuthorAsync(string auther)
        {
            var book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).Where(bookSelected => bookSelected.Author.ToUpper() == auther.ToUpper()).ToListAsync();
            if (!book.Any())
            {
                throw new KeyNotFoundException("Not Found");
            }

            return book.Select(bookSelected => new GetBookByAuthorResponse
            {
                Title = bookSelected.Title,
                Stock = bookSelected.Stock,
                BookCategory = bookSelected.BookCategory.CategoryName,
            }).ToList();

        }

        public async Task<string> UpdateAsync(UpdateBookRequest bookRequest)
        {
            var book = _dbcontext.Books.Find(bookRequest.Id);
            if (book == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            book.Stock = bookRequest.Stock;
            await _dbcontext.SaveChangesAsync();
            return ("Update Successfully");
         }

        public async Task<string> AddAsync(AddBookRequest bookRequest)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == bookRequest.BookCategory.CategoryName.ToUpper());
            if (category is null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            var addBook = new Books()
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                Stock = bookRequest.Stock,
                BookCategory = category,
            };

            _dbcontext.Books.Add(addBook);
            await _dbcontext.SaveChangesAsync();

            return "Book Added Successfully!";
        }

        public async Task<string> DeleteAsync(string bookName)
        {
            var book = await _dbcontext.Books.FirstOrDefaultAsync(BookSelected => BookSelected.Title.ToUpper() == bookName.ToUpper());
            if (book is null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _dbcontext.Books.Remove(book);
            await _dbcontext.SaveChangesAsync();
            return ("Deleted Saccussefully");
        }

    }

}

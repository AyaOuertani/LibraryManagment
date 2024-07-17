using LibraryManagment.Data;
using LibraryManagment.DTO.Books.Requests;
using LibraryManagment.DTO.Books.Responses;
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
        public async Task<IEnumerable<GetAllBooksResponsesDTO>> GetAllBooksAsync()
        {
            var books = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).Select(bookSelected => new GetAllBooksResponsesDTO
            {
                Title = bookSelected.Title,
                Author = bookSelected.Author,
                Stock = bookSelected.Stock,
                BookCategory = bookSelected.BookCategory.CategoryName
            }).ToListAsync();

            return books;
        }
        public async Task<GetBookByIdResponseDTO> GetBookByIdAsync(GetBookByIdRequestDTO bookByIdRequestDTO)
        {
            var book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).FirstOrDefaultAsync(bookSelected => bookSelected.ID == bookByIdRequestDTO.ID);
            if (book is null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new GetBookByIdResponseDTO
            {
                Title = book.Title,
                Author = book.Author,
                Stock = book.Stock,
                BookCategory = book.BookCategory.CategoryName,
            };

        }

        public async Task<GetBookByTitleResponseDTO> GetBookByTitleAsync (GetBookByTitleRequestDTO bookByTitleRequestDTO)
        {
            var book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).FirstOrDefaultAsync(bookSelected => bookSelected.Title.ToUpper() == bookByTitleRequestDTO.Title.ToUpper());
            if (book is null){
                throw new KeyNotFoundException("Not Found");
            }
            return new GetBookByTitleResponseDTO {
                Author = book.Author,
                Stock= book.Stock,
                BookCategory= book.BookCategory.CategoryName,
            };
        }

        public async Task<IEnumerable<GetBookByCategoryResponseDTO>> GetBookByCategoryAsync(GetBookByCategoryRequestDTO bookByCategoryRequestDTO)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName == bookByCategoryRequestDTO.CategoryName);
            if (category == null)
            {
                throw new KeyNotFoundException("Not Found"); 
            }
            var books =  await _dbcontext.Books.Where(bookSelected => bookSelected.BookCategory.CategoryID == category.CategoryID).ToListAsync();
            return books.Select(bookSelected => new GetBookByCategoryResponseDTO
            {
                Title = bookSelected.Title,
                Author = bookSelected.Author,
                Stock = bookSelected.Stock
            }).ToList();
        }

        public async Task<IEnumerable<GetBookByAuthorResponseDTO>> GetBookByAuthorAsync(GetBookByAuthorRequestDTO bookByAuthorRequestDTO)
        {
            var book = await _dbcontext.Books.Include(bookSelected => bookSelected.BookCategory).Where(bookSelected => bookSelected.Author.ToUpper() ==  bookByAuthorRequestDTO.Author.ToUpper()).ToListAsync();
            if (!book.Any())
            {
                throw new KeyNotFoundException("Not Found");
            }

            return book.Select(bookSelected => new GetBookByAuthorResponseDTO
            {
                Title = bookSelected.Title,
                Stock = bookSelected.Stock,
                BookCategory = bookSelected.BookCategory.CategoryName,
            }).ToList();

        }

        public async Task<string> UpdateBookAsync(UpdateBookRequestDTO bookRequestDTO)
        {
            var book = _dbcontext.Books.Find(bookRequestDTO.Id);
            if (book == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            book.Stock = bookRequestDTO.Stock;
            await _dbcontext.SaveChangesAsync();
            return ("Update Successfully");
         }

        public async Task<string> AddBookAsync(AddBookRequestDTO bookRequestDTO)
        {
            var category = await _dbcontext.Categories.FirstOrDefaultAsync(categorySelected => categorySelected.CategoryName.ToUpper() == bookRequestDTO.BookCategory.CategoryName.ToUpper());
            if (category is null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            var addBook = new Books()
            {
                Title = bookRequestDTO.Title,
                Author = bookRequestDTO.Author,
                Stock = bookRequestDTO.Stock,
                BookCategory = category,
            };

            _dbcontext.Books.Add(addBook);
            await _dbcontext.SaveChangesAsync();

            return "Book Added Successfully!";
        }

        public async Task<string> DeleteBookAsync(DeleteBookRequestDTO bookRequestDTO)
        {
            var book = await _dbcontext.Books.FirstOrDefaultAsync(BookSelected => BookSelected.Title.ToUpper() == bookRequestDTO.BookName.ToUpper());
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

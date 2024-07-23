using LibraryManagment.DTOs.BooksDTOs;
using LibraryManagment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region Books
    public class BooksController : ControllerBase
    {
        #region Variable+Constructor
        private readonly IBooksService _booksService;
        public BooksController(IBooksService bookService) => _booksService = bookService;
        #endregion

        #region Get
        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize) => Ok(await _booksService.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _booksService.GetByIdAsync(id));
        #endregion

        #region ByTitle
        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetByTitleAsync(string title) => Ok(await _booksService.GetByTitleAsync(title));
        #endregion

        #region ByCategory
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategoryAsync(string category) => Ok(await _booksService.GetByCategoryAsync(category));
        #endregion

        #region ByAuther
        [HttpGet("auther/{auther}")]
        public async Task<IActionResult> GetByAuthorAsync(string auther) => Ok(await _booksService.GetByAuthorAsync(auther));
        #endregion

        #endregion

        #region Post/Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddBookRequest bookRequest)
        {

            return await _booksService.AddAsync(bookRequest) ? Ok("Book Added Successfully!") : NotFound("Impossible To Add");
        }

        #endregion

        #region Put/Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBooksRequest bookRequest)
        {
            return await _booksService.UpdateAsync(bookRequest) ? Ok("Update Successfully") : NotFound("Impossible To Update");
        }

        #endregion

        #region Delete
        [HttpDelete("book/{book}")]
        public async Task<IActionResult> DeleteAsync(string book)
        {
            return await _booksService.DeleteAsync(book) ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion
    }
    #endregion
}

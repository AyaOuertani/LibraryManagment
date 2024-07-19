using LibraryManagment.DTOs.BooksDTOs.Requests;
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
        #region GetRequest
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _booksService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _booksService.GetByIdAsync(id));

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetByTitleAsync(string title) => Ok(await _booksService.GetByTitleAsync(title));

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategoryAsync(string category) => Ok(await _booksService.GetByCategoryAsync(category));

        [HttpGet("auther/{auther}")]
        public async Task<IActionResult> GetByAuthorAsync(string auther) => Ok(await _booksService.GetByAuthorAsync(auther));

        #endregion
        #region PostRequest
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddBookRequest bookRequest)  => Ok(await _booksService.AddAsync(bookRequest));

        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBookRequest bookRequest) => Ok(await _booksService.UpdateAsync(bookRequest));

        #endregion
        #region Delete
        [HttpDelete("book/{book}")]
        public async Task<IActionResult> DeleteAsync(string book) => Ok (await _booksService.DeleteAsync(book));
        #endregion
    }
    #endregion
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Interface;
using LibraryManagment.DTO.Books.Requests;
using LibraryManagment.Models;
using LibraryManagment.DTO.Category;
using LibraryManagment.Services;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController (IBooksService bookService)
        {
            _booksService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync() {
            var result = await _booksService.GetAllBooksAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route(("{id:int}"))]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var bookByIdRequestDTO = new GetBookByIdRequestDTO { ID = id };
            var result = await _booksService.GetBookByIdAsync(bookByIdRequestDTO);
            return Ok(result);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetBookByTitleAsync(string title)
        {
            var bookByTitleRequestDTO = new GetBookByTitleRequestDTO { Title = title };
            var result = await _booksService.GetBookByTitleAsync(bookByTitleRequestDTO);
            return Ok(result);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetBookByCategoryAsync([FromRoute] CategoryDTO category)
        {
            var bookByCategoryRequestDTO = new GetBookByCategoryRequestDTO { BookCategory = category };
            var result = await _booksService.GetBookByCategoryAsync(bookByCategoryRequestDTO);
            return Ok(result);
        }

        [HttpGet("auther/{auther}")]

        public async Task<IActionResult> GetBookByAuthorAsync(string auther)
        {
            var bookByAutherRequestDTO = new GetBookByAuthorRequestDTO { Author = auther };
            var result = await _booksService.GetBookByAuthorAsync(bookByAutherRequestDTO);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync (AddBookRequestDTO bookRequestDTO)
        {
            var result = await _booksService.AddBookAsync(bookRequestDTO);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBookAsync(UpdateBookRequestDTO bookRequestDTO)
        {
            var result = await _booksService.UpdateBookAsync(bookRequestDTO);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync(DeleteBookRequestDTO bookRequestDTO)
        {
            await _booksService.DeleteBookAsync(bookRequestDTO);
            return Ok();
        }

    }
}

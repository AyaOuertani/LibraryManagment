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
        public BooksController(IBooksService bookService) => _booksService = bookService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var result = await _booksService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _booksService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetByTitleAsync(string title)
        {
            var result = await _booksService.GetByTitleAsync(title);
            return Ok(result);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategoryAsync( string category)
        {
            var result = await _booksService.GetByCategoryAsync(category);
            return Ok(result);
        }

        [HttpGet("auther/{auther}")]

        public async Task<IActionResult> GetByAuthorAsync(string auther)
        {
            var result = await _booksService.GetByAuthorAsync(auther);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync (AddBookRequest bookRequestDTO)
        {
            var result = await _booksService.AddAsync(bookRequestDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBookRequest bookRequestDTO)
        {
            var result = await _booksService.UpdateAsync(bookRequestDTO);
            return Ok(result);
        }

        [HttpDelete ("book/{book}")]
        public async Task<IActionResult> DeleteAsync(string book )
        {
            var  result = await _booksService.DeleteAsync(book);
            return Ok(result);
        }

    }
}

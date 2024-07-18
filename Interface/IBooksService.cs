using LibraryManagment.Models;
using LibraryManagment.DTOs.BooksDTOs.Requests;
using LibraryManagment.DTOs.BooksDTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Interface
{
    public interface IBooksService
    {
        public Task<IEnumerable<GetAllBooksResponses>> GetAllAsync();

        public Task<GetBookByIdResponse> GetByIdAsync(int id);

        public Task<GetBookByTitleResponse> GetByTitleAsync(string title);

        public Task<IEnumerable<GetBookByCategoryResponse>> GetByCategoryAsync(string categooryName);

        public Task<IEnumerable<GetBookByAuthorResponse>> GetByAuthorAsync(string auther);

        public Task<string> AddAsync(AddBookRequest bookRequest);

        public Task<string> UpdateAsync(UpdateBookRequest bookRequest);

        public Task<string> DeleteAsync(string bookName);
    }
}

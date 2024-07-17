using LibraryManagment.Models;
using LibraryManagment.DTO.Books.Requests;
using LibraryManagment.DTO.Books.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Interface
{
    public interface IBooksService
    {
        public Task<IEnumerable<GetAllBooksResponsesDTO>> GetAllBooksAsync();

        public Task<GetBookByIdResponseDTO> GetBookByIdAsync(GetBookByIdRequestDTO  bookByIdRequestDTO);

        public Task<GetBookByTitleResponseDTO> GetBookByTitleAsync(GetBookByTitleRequestDTO bookByTitleRequestDTO);

        public Task<IEnumerable<GetBookByCategoryResponseDTO>> GetBookByCategoryAsync(GetBookByCategoryRequestDTO bookByCategoryRequestDTO);

        public Task<IEnumerable<GetBookByAuthorResponseDTO>> GetBookByAuthorAsync(GetBookByAuthorRequestDTO bookByAuthorRequestDTO);

        public Task<string> AddBookAsync(AddBookRequestDTO bookRequestDTO);

        public Task<string> UpdateBookAsync(UpdateBookRequestDTO bookRequestDto);

        public Task<string> DeleteBookAsync(DeleteBookRequestDTO bookRequestDTO);
    }
}

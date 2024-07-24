using LibraryManagment.DTOs.BooksDTOs;
using LibraryManagment.Models;


namespace LibraryManagment.Interface
{
    public interface IBooksService
    {
        public Task<PaginatedList<GetAllBooksResponse>> GetAllAsync(int pageNumber , int pageSize);

        public Task<GetBookByIdResponse> GetByIdAsync(int id);

        public Task<GetBookByTitleResponse> GetByTitleAsync(string title);

        public Task<IEnumerable<GetBooksByCategoryResponse>> GetByCategoryAsync(string categooryName);

        public Task<IEnumerable<GetBooksByAuthorResponse>> GetByAuthorAsync(string auther);

        public Task<AddBookResponse> AddAsync(AddBookRequest bookRequest);

        public Task<UpdateBooksResponse> UpdateAsync(UpdateBooksRequest bookRequest);

        public Task<bool> DeleteAsync(string bookName);
    }
}

using LibraryManagment.DTOs.BooksDTOs;


namespace LibraryManagment.Interface
{
    public interface IBooksService
    {
        public Task<IEnumerable<GetAllBooksResponse>> GetAllAsync(int pageNumber , int pageSize);

        public Task<GetBookByIdResponse> GetByIdAsync(int id);

        public Task<GetBookByTitleResponse> GetByTitleAsync(string title);

        public Task<IEnumerable<GetBooksByCategoryResponse>> GetByCategoryAsync(string categooryName);

        public Task<IEnumerable<GetBooksByAuthorResponse>> GetByAuthorAsync(string auther);

        public Task<AddBookResponse> AddAsync(AddBookRequest bookRequest);

        public Task<UpdateBooksResponse> UpdateAsync(UpdateBooksRequest bookRequest);

        public Task<DeleteBookResponse> DeleteAsync(string bookName);
    }
}

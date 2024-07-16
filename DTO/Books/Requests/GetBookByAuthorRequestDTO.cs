using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Requests
{
    public class GetBookByAuthorRequestDTO
    {
        public string Author { get; set; } = string.Empty;

    }
}

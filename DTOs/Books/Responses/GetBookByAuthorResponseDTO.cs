using LibraryManagment.DTO.Category;
using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Responses
{
    public class GetBookByAuthorResponseDTO
    {
        public required string Title { get; set; }
        public int Stock { get; set; }
        public String BookCategory { get; set; }
    }
}

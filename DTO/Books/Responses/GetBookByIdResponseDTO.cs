using LibraryManagment.DTO.Category;
using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Responses
{
    public class GetBookByIdResponseDTO
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string BookCategory { get; set; }
    }
}

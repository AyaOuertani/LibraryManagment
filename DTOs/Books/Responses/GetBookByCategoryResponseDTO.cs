using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Responses
{
    public class GetBookByCategoryResponseDTO
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}

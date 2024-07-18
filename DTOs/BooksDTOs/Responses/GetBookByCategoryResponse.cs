using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByCategoryResponse
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}

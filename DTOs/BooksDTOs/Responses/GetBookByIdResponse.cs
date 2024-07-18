
using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByIdResponse
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string BookCategory { get; set; }= string.Empty;
    }
}

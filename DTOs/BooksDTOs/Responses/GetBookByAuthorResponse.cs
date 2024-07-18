
using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByAuthorResponse
    {
        public required string Title { get; set; }
        public int Stock { get; set; }
        public string BookCategory { get; set; }
    }
}

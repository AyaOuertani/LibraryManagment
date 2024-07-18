using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByTitleResponse
    {
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string BookCategory { get; set; }
    }
}

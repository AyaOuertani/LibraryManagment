
using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByAuthorResponse
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public string? BookCategory { get; set; }
        public GetBookByAuthorResponse(string title, int stock, string? bookCategory)
        {
            Title = title;
            Stock = stock;
            BookCategory = bookCategory;
        }
    }
}

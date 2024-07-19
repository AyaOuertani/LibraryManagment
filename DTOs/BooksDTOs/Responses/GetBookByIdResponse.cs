
using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByIdResponse
    {
        public string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string BookCategory { get; set; }= string.Empty;
        public GetBookByIdResponse(string title, string author, int stock, string bookCategory)
        {
            Title = title;
            Author = author;
            Stock = stock;
            BookCategory = bookCategory;
        }
    }
}

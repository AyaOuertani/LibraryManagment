using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetBookByCategoryResponse
    {
        public  string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public GetBookByCategoryResponse(string title, string author, int stock)
        {
            Title = title;
            Author = author;
            Stock = stock;
        }
    }
}

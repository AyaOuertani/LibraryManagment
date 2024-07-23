using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs
{
    public class AddBookResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public Category BookCategory { get; set; }
        public AddBookResponse(string title, string author, int stock, Category bookCategory)
        {
            Title = title;
            Author = author;
            Stock = stock;
            BookCategory = bookCategory;
        }

    }
}

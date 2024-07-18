using LibraryManagment.DTO.Category;
using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Requests
{
    public class AddBookRequest
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public Category.Category BookCategory { get; set; }
    }
}

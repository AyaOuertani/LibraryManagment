using LibraryManagment.DTOs.CategoriesDTOs;

namespace LibraryManagment.DTOs.BooksDTOs
{
    public class AddBookRequest
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public AddCategoryRequest? BookCategory { get; set; }
    }
}

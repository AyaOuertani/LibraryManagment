using LibraryManagment.DTOs.CategoryDTOs;
using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs.Requests
{
    public class AddBookRequest
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public CategoryDTOs.Category BookCategory { get; set; }
    }
}

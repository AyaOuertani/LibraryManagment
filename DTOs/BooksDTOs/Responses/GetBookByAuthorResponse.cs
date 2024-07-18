using LibraryManagment.DTO.Category;
using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Responses
{
    public class GetBookByAuthorResponse
    {
        public required string Title { get; set; }
        public int Stock { get; set; }
        public String BookCategory { get; set; }
    }
}

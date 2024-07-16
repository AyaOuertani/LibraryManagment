using LibraryManagment.DTO.Category;
namespace LibraryManagment.DTO.Books.Responses
{
    public class GetAllBooksResponsesDTO
    {
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string BookCategory { get; set; }
    }
}

namespace LibraryManagment.DTOs.BooksDTOs
{
    public class GetBooksByAuthorResponse
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public string? BookCategory { get; set; }
        public GetBooksByAuthorResponse(string title, int stock, string? bookCategory)
        {
            Title = title;
            Stock = stock;
            BookCategory = bookCategory;
        }
    }
}

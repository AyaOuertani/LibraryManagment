namespace LibraryManagment.DTOs.BooksDTOs
{
    public class GetBookByTitleResponse
    {
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string BookCategory { get; set; } = string.Empty;
        public GetBookByTitleResponse(string author, int stock, string bookCategory)
        {
            Author = author;
            Stock = stock;
            BookCategory = bookCategory;
        }
    }
}

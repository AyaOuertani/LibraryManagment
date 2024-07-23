namespace LibraryManagment.DTOs.BooksDTOs
{
    public class GetBooksByCategoryResponse
    {
        public string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public GetBooksByCategoryResponse(string title, string author, int stock)
        {
            Title = title;
            Author = author;
            Stock = stock;
        }
    }
}

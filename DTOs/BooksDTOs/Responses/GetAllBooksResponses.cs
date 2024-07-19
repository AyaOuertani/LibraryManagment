namespace LibraryManagment.DTOs.BooksDTOs.Responses
{
    public class GetAllBooksResponses
    {
        public  string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string BookCategory { get; set; } =string.Empty;

        public GetAllBooksResponses (string title, string author, int stock, string bookCategory)
        {
            Title = title;
            Author = author;
            Stock = stock;
            BookCategory = bookCategory;
        }
    }
}

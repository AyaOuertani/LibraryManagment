namespace LibraryManagment.DTOs.BooksDTOs
{
    public class GetAllBooksResponse
    {
            public string Title { get; set; }
            public string Author { get; set; } = string.Empty;
            public int Stock { get; set; }
            public int CategoryId { get; set; }
            public string BookCategory { get; set; } = string.Empty;

            public GetAllBooksResponse(string title, string author, int stock, string bookCategory)
            {
                Title = title;
                Author = author;
                Stock = stock;
                BookCategory = bookCategory;
            }
        
    }

}

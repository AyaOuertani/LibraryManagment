namespace LibraryManagment.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; } 
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category BookCategory { get; set; }
        public ICollection<Loan>? Loans { get; set; }
        public Books() { }
        public Books( string title, string author, int stock, Category bookCategory)
        {
            Title = title;
            Author = author;
            Stock = stock;
            BookCategory = bookCategory;
        }
    }
}

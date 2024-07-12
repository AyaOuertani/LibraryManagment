namespace LibraryManagment.Models
{
    public class Books
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Stock { get; set; }
        public Category BookCategory { get; set; } = new Category();
    }
}

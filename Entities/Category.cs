namespace LibraryManagment.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<Books>? Books { get; set; }
        public Category(string categoryName) => CategoryName = categoryName;
    }
}

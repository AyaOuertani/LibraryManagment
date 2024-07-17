namespace LibraryManagment.DTOs.Categories
{
    public class GetAllCategoriesResponse
    {
        public string CategoryName { get; set; } = string.Empty;
        public List<string> BooksTitle  { get; set; }
    }
}

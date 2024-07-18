namespace LibraryManagment.DTOs.CategoryDTOs
{
    public class GetAllCategoriesResponse
    {
        public string CategoryName { get; set; } = string.Empty;
        public List<string> BooksTitle  { get; set; }
    }
}

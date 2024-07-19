namespace LibraryManagment.DTOs.CategoriesDTOs.Responses
{
    public class GetAllCategoriesResponse
    {
        public string CategoryName { get; set; } = string.Empty;
        public List<string>? BooksTitle { get; set; }

        public GetAllCategoriesResponse(string categoryName, List<string>? booksTitle)
        {
            CategoryName = categoryName;
            BooksTitle = booksTitle;
        }
    }
}

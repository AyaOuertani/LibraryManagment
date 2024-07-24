namespace LibraryManagment.DTOs.CategoriesDTOs
{
    public class AddCategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public AddCategoryResponse(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

    }
}

namespace LibraryManagment.DTOs.CategoriesDTOs
{
    public class AddCategoryResponse
    {
        public bool Add {  get; set; }
        public AddCategoryResponse(bool add = true) => Add = add;
    }
}

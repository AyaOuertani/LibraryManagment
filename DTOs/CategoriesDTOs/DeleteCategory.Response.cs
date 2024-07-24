namespace LibraryManagment.DTOs.CategoriesDTOs
{
    public class DeleteCategoryResponse
    {
        public bool Delete { get; set; }
        public DeleteCategoryResponse(bool delete =true)
        {
            Delete = delete;
        }
    }
}

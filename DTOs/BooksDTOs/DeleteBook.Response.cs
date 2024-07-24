namespace LibraryManagment.DTOs.BooksDTOs
{
    public class DeleteBookResponse
    {
        public bool Delete {  get; set; }
        public DeleteBookResponse(bool delete = true)
        {
            Delete = delete;
        }
    }
}

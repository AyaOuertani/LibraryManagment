namespace LibraryManagment.DTOs.BooksDTOs.Requests
{
    public class UpdateBookRequest
    {
        public string Title { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
 
namespace LibraryManagment.DTOs.BooksDTOs
{
    public class UpdateBooksRequest
    {
        public string Title { get; set; } = string.Empty;
        public int? Stock { get; set; }
    }
}

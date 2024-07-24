namespace LibraryManagment.DTOs.BooksDTOs
{
    public class UpdateBooksResponse
    {
        public bool Update { get; set; }
        public UpdateBooksResponse(bool update = true) => Update = update;
    }
}

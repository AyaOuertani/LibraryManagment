namespace LibraryManagment.DTOs.BooksDTOs
{
    public class AddBookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AddBookResponse(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}

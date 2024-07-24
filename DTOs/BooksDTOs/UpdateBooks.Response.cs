namespace LibraryManagment.DTOs.BooksDTOs
{
    public class UpdateBooksResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Stock {  get; set; }
        public UpdateBooksResponse(int iD, string title, int stock)
        {
            ID = iD;
            Title = title;
            Stock = stock;
        }
    }
}

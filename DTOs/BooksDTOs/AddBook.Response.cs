using LibraryManagment.Models;

namespace LibraryManagment.DTOs.BooksDTOs
{
    public class AddBookResponse
    {
        public bool Add {  get; set; }
        public AddBookResponse(bool add = true) => Add = add;
    }
}

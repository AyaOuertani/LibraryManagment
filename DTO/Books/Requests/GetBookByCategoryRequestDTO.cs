using LibraryManagment.DTO.Category;
using LibraryManagment.Models;

namespace LibraryManagment.DTO.Books.Requests
{
    public class GetBookByCategoryRequestDTO
    {
        public int CategoryId { get; set; }
        public CategoryDTO BookCategory { get; set; }
    }
}


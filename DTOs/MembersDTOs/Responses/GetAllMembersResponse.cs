using LibraryManagment.Models;

namespace LibraryManagment.DTOs.MembersDTOs.Responses
{
    public class GetAllMembersResponse
    {

        public int MemberID { get; set; }
        public  string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public  string Phone { get; set; }
        public List<string>? Bookloaned { get; set; }
        public GetAllMembersResponse(int memberID, string name, int age, string email, string phone, List<string>? bookloaned)
        {
            MemberID = memberID;
            Name = name;
            Age = age;
            Email = email;
            Phone = phone;
            Bookloaned = bookloaned;
        }
    }
}

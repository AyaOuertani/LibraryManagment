namespace LibraryManagment.DTOs.MembersDTOs
{
    public class GetMemberByIdResponse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
        public GetMemberByIdResponse(string name, int age, string email, string phone)
        {
            Name = name;
            Age = age;
            Email = email;
            Phone = phone;
        }
    }
}

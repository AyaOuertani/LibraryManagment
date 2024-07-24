namespace LibraryManagment.DTOs.MembersDTOs
{
    public class UpdateMemberResponse
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UpdateMemberResponse(int id, int age, string email, string phone)
        {
            Id = id;
            Age = age;
            Email = email;
            Phone = phone;
        }
    }
}

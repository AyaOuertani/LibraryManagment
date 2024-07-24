namespace LibraryManagment.DTOs.MembersDTOs
{
    public class AddMemberResponse
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; }
        public AddMemberResponse(int memberId, string name, string phone)
        {
            MemberId = memberId;
            Name = name;
            Phone = phone;
        }
    }
}

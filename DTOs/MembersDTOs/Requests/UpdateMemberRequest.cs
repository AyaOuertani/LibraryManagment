namespace LibraryManagment.DTOs.MembersDTOs.Requests
{
    public class UpdateMemberRequest
    {
        public int MemberID { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public required string Phone { get; set; }
    }
}

namespace LibraryManagment.DTOs.MembersDTOs
{
    public class UpdateMemberRequest
    {
        public int MemberID { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; } 
        public string? Phone { get; set; } 
    }
}

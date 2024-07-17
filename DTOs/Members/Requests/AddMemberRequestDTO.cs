namespace LibraryManagment.DTO.Members.Requests
{
    public class AddMemberRequestDTO
    {
        public required string Name { get; set;}
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public required string Phone { get; set; }
    }
}

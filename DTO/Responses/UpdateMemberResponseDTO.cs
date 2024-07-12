namespace LibraryManagment.DTO.Responses
{
    public class UpdateMemberResponseDTO
    {
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public required string Phone { get; set; }
    }
}

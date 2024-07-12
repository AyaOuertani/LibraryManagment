﻿namespace LibraryManagment.DTO.Requests
{
    public class UpdateMemberRequestDTO
    {
        public int MemberID { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public required string Phone { get; set; }
    }
}
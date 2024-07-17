﻿namespace LibraryManagment.DTO.Members.Responses
{
    public class GetMemberByIdResponseDTO
    {
        public required string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public required string Phone { get; set; }
    }
}
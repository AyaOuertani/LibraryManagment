using LibraryManagment.Data;
using LibraryManagment.DTO.Members.Requests;
using LibraryManagment.DTO.Members.Responses;
using LibraryManagment.Models;
using LibraryManagment.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Interface
{
    public interface IMemberService
    {
        public List<Member> GetAllMembers();

        public Task<GetMemberByIdResponseDTO> GetMemberByIdAsync(GetMemberByIdRequestDTO memberByIdRequestDTO);

        public  Task<string> AddMemberAsync(AddMemberRequestDTO MemberRequestDto);

        public Task<string> UpdateMemberAsync(UpdateMemberRequestDTO updateMemberDto);

        public Task DeleteMemberAsync(DeleteMemberRequestDTO deleteMemberRequestDTO);

    }
}

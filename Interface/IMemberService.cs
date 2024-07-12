using LibraryManagment.DTO.Requests;
using LibraryManagment.DTO.Responses;
using LibraryManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Interface
{
    public interface IMemberService
    {
        public List<Member> GetAllMembers();

        public GetMemberByIdResponseDTO GetMemberById(GetMemberByIdRequestDTO memberByIdRequestDTO);

        public  Task<string> AddMemberAsync(AddMemberRequestDTO MemberRequestDto);

        public Task<string> UpdateMemberAsync(UpdateMemberRequestDTO updateMemberDto);


    }
}

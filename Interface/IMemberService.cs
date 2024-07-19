using LibraryManagment.Data;
using LibraryManagment.DTOs.MembersDTOs.Requests;
using LibraryManagment.DTOs.MembersDTOs.Responses;
using LibraryManagment.Models;
using LibraryManagment.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Interface
{
    public interface IMemberService
    {
        public Task<IEnumerable<GetAllMembersResponse>> GetAllAsync();

        public Task<GetMemberByIdResponse> GetByIdAsync(int id);

        public  Task<string> AddAsync(AddMemberRequest memberRequest);

        public Task<string> UpdateAsync(UpdateMemberRequest updateMember);

        public Task<string> DeleteAsync(int id);

    }
}

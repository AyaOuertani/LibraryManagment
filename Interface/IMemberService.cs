using LibraryManagment.DTOs.MembersDTOs;
using LibraryManagment.Models;


namespace LibraryManagment.Interface
{
    public interface IMemberService
    {
        public Task<PaginatedList<GetAllMemberResponse>> GetAllAsync(int pageNumber,int pageSize);

        public Task<GetMemberByIdResponse> GetByIdAsync(int id);

        public Task<AddMemberResponse> AddAsync(AddMemberRequest memberRequest);

        public Task<UpdateMemberResponse> UpdateAsync(UpdateMemberRequest updateMember);

        public Task<bool> DeleteAsync(int id);

    }
}

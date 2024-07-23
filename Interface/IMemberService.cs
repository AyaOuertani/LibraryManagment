using LibraryManagment.DTOs.MembersDTOs;


namespace LibraryManagment.Interface
{
    public interface IMemberService
    {
        public Task<IEnumerable<GetAllMemberResponse>> GetAllAsync(int pageNumber,int pageSize);

        public Task<GetMemberByIdResponse> GetByIdAsync(int id);

        public Task<bool> AddAsync(AddMemberRequest memberRequest);

        public Task<bool> UpdateAsync(UpdateMemberRequest updateMember);

        public Task<bool> DeleteAsync(int id);

    }
}

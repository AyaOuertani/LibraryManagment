using LibraryManagment.DTOs.MembersDTOs;


namespace LibraryManagment.Interface
{
    public interface IMemberService
    {
        public Task<IEnumerable<GetAllMemberResponse>> GetAllAsync(int pageNumber,int pageSize);

        public Task<GetMemberByIdResponse> GetByIdAsync(int id);

        public Task<AddMemberResponse> AddAsync(AddMemberRequest memberRequest);

        public Task<UpdateMemberResponse> UpdateAsync(UpdateMemberRequest updateMember);

        public Task<DeleteMemberResponse> DeleteAsync(int id);

    }
}

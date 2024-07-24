namespace LibraryManagment.DTOs.MembersDTOs
{
    public class DeleteMemberResponse
    {
        public bool Delete {  get; set; }
        public DeleteMemberResponse(bool delete = true) => Delete = delete;
    }
}

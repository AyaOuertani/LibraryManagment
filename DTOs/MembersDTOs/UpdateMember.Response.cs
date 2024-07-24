namespace LibraryManagment.DTOs.MembersDTOs
{
    public class UpdateMemberResponse
    {
        public bool Update {  get; set; }
        public UpdateMemberResponse(bool update = true) => Update = update;
    }
}

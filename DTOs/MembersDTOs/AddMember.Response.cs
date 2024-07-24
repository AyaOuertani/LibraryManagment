namespace LibraryManagment.DTOs.MembersDTOs
{
    public class AddMemberResponse
    {
        public bool Add { get; set; }
        public AddMemberResponse(bool add = true) => Add = add;
    }
}

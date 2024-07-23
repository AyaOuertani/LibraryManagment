namespace LibraryManagment.DTOs.LoansDTOs
{
    public class GetByIdLoansResponse
    {
        public string MemberName { get; set; } = string.Empty;
        public string PhoneN { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> BookTitle { get; set; } = new List<string>();
        public GetByIdLoansResponse(string memberName, string phoneN, string email, List<string> bookTitle)
        {
            MemberName = memberName;
            PhoneN = phoneN;
            Email = email;
            BookTitle = bookTitle;
        }
    }
}

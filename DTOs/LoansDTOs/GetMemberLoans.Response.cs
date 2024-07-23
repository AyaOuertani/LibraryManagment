namespace LibraryManagment.DTOs.LoansDTOs
{
    public class GetMemberLoansResponse
    {
        public int LoanId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public string PhoneN { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> BookTitle { get; set; } = new List<string>();
        public GetMemberLoansResponse(string memberName, string phoneN, string email, List<string> bookTitle)
        {
            MemberName = memberName;
            PhoneN = phoneN;
            Email = email;
            BookTitle = bookTitle;
        }
    }
}

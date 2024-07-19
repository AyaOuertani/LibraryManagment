namespace LibraryManagment.DTOs.LoansDTOs.Response
{
    public class GetMemberLoansResponse
    {
        public int LoanId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public string PhoneN { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> BookTitle { get; set; } = new List<string>();
        public GetMemberLoansResponse(int loanId, string memberName, string phoneN, string email, List<string> bookTitle)
        {
            LoanId = loanId;
            MemberName = memberName;
            PhoneN = phoneN;
            Email = email;
            BookTitle = bookTitle;
        }
    }
}

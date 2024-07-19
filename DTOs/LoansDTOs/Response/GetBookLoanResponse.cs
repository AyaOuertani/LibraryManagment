namespace LibraryManagment.DTOs.LoansDTOs.Response
{
    public class GetBookLoanResponse
    {
        public int LoanId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
        public GetBookLoanResponse(int loanId, string bookTitle, string memberName)
        {
            LoanId = loanId;
            BookTitle = bookTitle;
            MemberName = memberName;
        }
    }
}

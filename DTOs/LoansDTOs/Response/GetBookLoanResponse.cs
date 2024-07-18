namespace LibraryManagment.DTOs.LoansDTOs.Response
{
    public class GetBookLoanResponse
    {
        public int LoanId { get; set; }
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
    }
}

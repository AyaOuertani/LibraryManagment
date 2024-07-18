namespace LibraryManagment.DTOs.LoansDTOs.Response
{
    public class GetMemberLoansResponse
    {
        public int LoanId { get; set; }
        public string MemberName { get; set; }
        public string PhoneN {  get; set; }
        public string Email { get; set; }
        public List<string> BookTitle { get; set; }
    }
}

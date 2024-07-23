namespace LibraryManagment.DTOs.LoansDTOs
{
    public class AddLoanRequest
    {
        public int MemberID { get; set; }
        public List<string>? BookTitle { get; set; }
    }
}

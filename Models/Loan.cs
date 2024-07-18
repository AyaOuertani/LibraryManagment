namespace LibraryManagment.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public  Books Books { get; set; }
        public Member Member { get; set; }

    }
}

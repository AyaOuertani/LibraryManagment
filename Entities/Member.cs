namespace LibraryManagment.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public  string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public  string Phone { get; set; } = string.Empty;
        public ICollection<Loan>? Loans { get; set; }
    }
}

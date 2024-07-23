using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagment.Models
{
    public class Loan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public Books? Books { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; }

    }
}

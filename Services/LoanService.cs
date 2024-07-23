using LibraryManagment.Data;
using LibraryManagment.DTOs.LoansDTOs;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagment.Services
{
    public class LoanService : ILoanService
    {
        #region Variable + Constroctor
        private readonly ApplicationDBcontext _dbcontext;
        public LoanService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get
        #region ByIdLoans
        public async Task<IEnumerable<GetByIdLoansResponse>> GetByIdLoansAsync(int id)
        {
            IEnumerable<Loan> bookLoans = await _dbcontext.Loans.Include(loanSelected => loanSelected.Books)
                                                                .Include(loanSelected => loanSelected.Member)
                                                                .Where(loanSelected => loanSelected.LoanId == id).ToListAsync();
            return (bookLoans.GroupBy(loan => new { loan.LoanId, loan.Member })
                             .Select(group => new GetByIdLoansResponse(group.Key.Member.Name,
                                                                       group.Key.Member.Phone,
                                                                       group.Key.Member.Email,
                                                                       group.Select(loan => loan.Books.Title).ToList())
                               )
                    );
        }
        #endregion

        #region BookLoans
        public async Task<IEnumerable<GetBookLoanResponse>> GetBookLoansAsync(string bookName)
        {
            List<Loan> bookloans = await _dbcontext.Loans.Include(loanSelected => loanSelected.Books)
                                                         .Include(loanSelected => loanSelected.Member)
                                                         .Where(loanSelected => loanSelected.Books.Title.ToUpper().Contains(bookName.ToUpper())).ToListAsync();

            return (bookloans.Select(loanSelected => new GetBookLoanResponse(loanSelected.LoanId,
                                                                             loanSelected.Books.Title,
                                                                             loanSelected.Member.Name)).ToList());
        }
        #endregion

        #region MemberLoans
        public async Task<IEnumerable<GetMemberLoansResponse>> GetMemberLoansAsync(int id)
        {
            IEnumerable<Loan> memberLoans = await _dbcontext.Loans.Include(loanSelected => loanSelected.Books)
                                                           .Include(loanSelected => loanSelected.Member)
                                                           .Where(loanSelected => loanSelected.Member.MemberID == id).ToListAsync();
            return (memberLoans.GroupBy(loan => new { loan.LoanId, loan.Member })
                               .Select(group => new GetMemberLoansResponse(group.Key.Member.Name,
                                                                           group.Key.Member.Phone,
                                                                           group.Key.Member.Email,
                                                                           group.Select(loan => loan.Books.Title).ToList())
                               )
                    );
        }
        #endregion
        #endregion

        #region Add
        public async Task<string> AddAsync(AddLoanRequest addLoanRequest)
        {
            Member? member = await _dbcontext.Members.FindAsync(addLoanRequest.MemberID)
                                                     ?? throw new KeyNotFoundException("Not Found !");

            List<Books> books = await _dbcontext.Books.Where(bookSelected => addLoanRequest.BookTitle.Contains(bookSelected.Title)).ToListAsync();

            List<string> unavailableBooks = books.Where(book => book.Stock == 0)
                                                 .Select(book => book.Title).ToList();
            if (unavailableBooks.Count == 0)
            {
                return ($"Out of stock: {string.Join(", ", unavailableBooks)}");
            }
            List<Loan> loans = [];
            foreach (var book in books)
            {
                loans.Add(new Loan
                {
                    MemberId = member.MemberID,
                    BookId = book.ID
                });
                book.Stock -= 1;
                _dbcontext.Books.Update(book);
            }
            await _dbcontext.Loans.AddRangeAsync(loans);
            await _dbcontext.SaveChangesAsync();
            return ("Added Successfully");
        }
        #endregion

        #region Delete 
        public async Task<bool> DeleteAsync(int loanId, int memberId)
        {
            Loan loan = await _dbcontext.Loans.FindAsync(loanId, memberId)
                                              ?? throw new KeyNotFoundException("Not Found");
            Books? bookLoaned = await _dbcontext.Books.FindAsync(loan.BookId);
            bookLoaned.Stock += 1;
            _dbcontext.Books.Update(bookLoaned);
            _dbcontext.Loans.Remove(loan);
            await _dbcontext.SaveChangesAsync();
            return (true);
        }
        #endregion
    }
}

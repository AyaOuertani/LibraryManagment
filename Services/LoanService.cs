﻿using LibraryManagment.Data;
using LibraryManagment.Interface;
using LibraryManagment.DTOs.LoansDTOs.Response;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagment.Services
{
    public class LoanService:ILoanService
    {
        private readonly ApplicationDBcontext _dbcontext;
        public LoanService(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<GetBookLoanResponse>> GetBookLoansAsync(string bookName)
        {
            var bookloans =await  _dbcontext.Loans.Include(loanSelected => loanSelected.Books).Include(loanSelected => loanSelected.Member).Where(loanSelected => loanSelected.Books.Title.ToUpper().Contains(bookName.ToUpper())).ToListAsync();
            var loans = bookloans.Select(loanSelected => new GetBookLoanResponse
            {
                LoanId = loanSelected.LoanId,
                BookTitle = loanSelected.Books.Title,
                MemberName = loanSelected.Member.Name

            }).ToList();
            return (loans);
        }
        public async Task<IEnumerable<GetMemberLoansResponse>> GetMemberLoansAsync(int id)
        {
            var memberLoans = await _dbcontext.Loans.Include(loanSelected => loanSelected.Books).Include(loanSelected => loanSelected.Member).Where(loanSelected => loanSelected.Member.MemberID == id).ToListAsync();
            var loans = memberLoans.GroupBy(loan => new { loan.LoanId, loan.Member }).Select(group => new GetMemberLoansResponse
            {
                LoanId = group.Key.LoanId,
                MemberName = group.Key.Member.Name,
                PhoneN = group.Key.Member.Phone,
                Email = group.Key.Member.Email,
                BookTitle = group.Select(loan => loan.Books.Title).ToList(),

            });
            return (loans);
        }
    }
}

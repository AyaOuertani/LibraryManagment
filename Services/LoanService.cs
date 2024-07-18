using LibraryManagment.Data;
using LibraryManagment.Interface;
using LibraryManagment.DTOs.Loans.Response;
namespace LibraryManagment.Services
{
    public class LoanService:ILoanService
    {
        private readonly ApplicationDBcontext _dbcontext;
        public LoanService(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<GetBookLoanResponse>> GetBookLoansAsync()
        {
            return [];
        }
    }
}

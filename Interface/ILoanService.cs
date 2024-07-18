using LibraryManagment.DTOs.Loans.Response;
namespace LibraryManagment.Interface
{
    public interface ILoanService
    {
        public Task<IEnumerable<GetBookLoanResponse>> GetBookLoansAsync();
    }
}

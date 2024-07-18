using LibraryManagment.DTOs.LoansDTOs.Response;
namespace LibraryManagment.Interface
{
    public interface ILoanService
    {
        public Task<IEnumerable<GetBookLoanResponse>> GetBookLoansAsync(string book);
        public Task<IEnumerable<GetMemberLoansResponse>> GetMemberLoansAsync(int id );
    }
}

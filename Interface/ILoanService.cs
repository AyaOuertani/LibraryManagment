using LibraryManagment.DTOs.LoansDTOs;
namespace LibraryManagment.Interface
{
    public interface ILoanService
    {
        public Task <IEnumerable<GetByIdLoansResponse>> GetByIdLoansAsync(int loansId);
        public Task<IEnumerable<GetBookLoanResponse>> GetBookLoansAsync(string book);

        public Task<IEnumerable<GetMemberLoansResponse>> GetMemberLoansAsync(int id);

        public Task<string> AddAsync(AddLoanRequest addLoanRequest);

        public Task<DeleteLoanResponse> DeleteAsync(int loanId, int memberId);

    }
}

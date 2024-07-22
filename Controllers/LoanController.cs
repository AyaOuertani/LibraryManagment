using LibraryManagment.DTOs.LoansDTOs.Request;
using LibraryManagment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Loan
    public class LoanController : ControllerBase
    {
        #region Variables+Constructor
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService) => _loanService = loanService;
        #endregion
        #region Get
        #region IdLoans
        [HttpGet("LoanId/{LoanId}")]
        public async Task<IActionResult> GetByIdLoanAync(int LoanId) => Ok(await _loanService.GetByIdLoansAsync(LoanId));
        #endregion
        #region BookLoans
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetBooksLoanAync(string Name) => Ok(await _loanService.GetBookLoansAsync(Name));
        #endregion
        #region MemberLoans
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetMemberLoanAsync(int id) => Ok(await _loanService.GetMemberLoansAsync(id));
        #endregion
        #endregion
        #region Post/Add
        [HttpPost]
        public async Task<IActionResult> AddAsyc(AddLoanRequest addLoanRequest) => Ok(await _loanService.AddAsync(addLoanRequest));
        #endregion
        #region Delete
        [HttpDelete("{loanId}/{memberId}")]
        public async Task<IActionResult> DeleteAsync(int loanId, int memberId) => Ok(await _loanService.DeleteAsync(loanId, memberId));
        #endregion
    }
    #endregion
}

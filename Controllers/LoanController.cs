using LibraryManagment.DTOs.LoansDTOs.Request;
using LibraryManagment.Interface;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetBooksLoanAync(string Name) => Ok(await _loanService.GetBookLoansAsync(Name));
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetMemberLoanAsync(int id) => Ok(await _loanService.GetMemberLoansAsync(id));
        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> AddAsyc(AddLoanRequest addLoanRequest) => Ok(await _loanService.AddAsync(addLoanRequest));
        #endregion
        #region Delete
        [HttpDelete("{loanId}")]
        public async Task<IActionResult> DeleteAsync(int loanId , int memberId) => Ok(await _loanService.DeleteAsync(loanId, memberId));
        #endregion
    }
    #endregion
}

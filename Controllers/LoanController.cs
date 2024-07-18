using LibraryManagment.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController (ILoanService loanService)
        {
            _loanService = loanService;
        }
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetBooksLoanAync(string Name)
        {
            var result = await _loanService.GetBookLoansAsync(Name);
            return Ok(result);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetMemberLoanAsync(int id)
        {
            var result = await _loanService.GetMemberLoansAsync(id);
            return Ok(result);
        }
    }
}

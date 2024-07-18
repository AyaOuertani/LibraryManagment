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
        [HttpGet]
        public async Task<IActionResult> GetBooksLoanAync()
        {
            var result = await _loanService.GetBookLoansAsync();
            return Ok(result);
        }
    }
}

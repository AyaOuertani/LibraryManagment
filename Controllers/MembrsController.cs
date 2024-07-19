using LibraryManagment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Services;
using LibraryManagment.DTOs.MembersDTOs.Responses;
using LibraryManagment.Interface;
using LibraryManagment.DTOs.MembersDTOs.Requests;
namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Members
    public class MembrsController : ControllerBase
    {
        #region Variables+Constructor
        private readonly IMemberService _memberServices;

        public MembrsController(IMemberService memberService) => _memberServices = memberService;
        #endregion
        #region Get
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _memberServices.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _memberServices.GetByIdAsync(id));
        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddMemberRequest memberRequest) => Ok(await _memberServices.AddAsync(memberRequest));
        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateMemberRequest memberRequest)=> Ok(await _memberServices.UpdateAsync(memberRequest));
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) => Ok(await _memberServices.DeleteAsync(id));
        #endregion
    }
    #endregion
}

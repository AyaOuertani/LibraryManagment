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
    public class MembrsController : ControllerBase
    {
        private readonly IMemberService _memberServices;
        
        public MembrsController(IMemberService memberService)
        {
            _memberServices = memberService;
        }
        
        [HttpGet]
        
        public IActionResult GetAll() => Ok(_memberServices.GetAll());
        
        [HttpGet("id/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var results = await _memberServices.GetByIdAsync(id);
            return Ok(results);
            
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync(AddMemberRequest memberRequest)
        {
            var result = await _memberServices.AddAsync(memberRequest);
            return Ok(result);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateMemberRequest memberRequest)
        {
            var result = await _memberServices.UpdateAsync(memberRequest);
            return Ok(result);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result=await _memberServices.DeleteAsync(id);
            return Ok(result);
        }
    }
}

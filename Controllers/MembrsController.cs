using LibraryManagment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Services;
using LibraryManagment.DTO.Members.Responses;
using LibraryManagment.Interface;
using LibraryManagment.DTO.Members.Requests;
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
        
        public IActionResult GetAllMemebrs() => Ok(_memberServices.GetAllMembers());
        
        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetMemberById(int id)
        {
            var memberByIdRequestDTO = new GetMemberByIdRequestDTO { MemberID = id };
            var results = await _memberServices.GetMemberByIdAsync(memberByIdRequestDTO);
            return Ok(results);
            
        }

        [HttpPost]

        public async Task<IActionResult> AddMemberAsync(AddMemberRequestDTO memberRequestDto)
        {
            var result = await _memberServices.AddMemberAsync(memberRequestDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateMemeberAsync(UpdateMemberRequestDTO memberRequestDTO)
        {
            var result = await _memberServices.UpdateMemberAsync(memberRequestDTO);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]


        public async Task<IActionResult> DeleteMemberAsync(DeleteMemberRequestDTO memberRequestDTO)
        {
            await _memberServices.DeleteMemberAsync(memberRequestDTO);
            return Ok();
        }
    }
}

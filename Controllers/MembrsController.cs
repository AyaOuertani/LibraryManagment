using LibraryManagment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Services;
using LibraryManagment.DTO.Requests;
using LibraryManagment.DTO.Responses;
using LibraryManagment.Interface;
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

        public IActionResult GetMemberById(int id)
        {
            var memberByIdRequestDTO = new GetMemberByIdRequestDTO { MemberID = id };
            return Ok(_memberServices.GetMemberById(memberByIdRequestDTO));
            
        }

        [HttpPost]

        public IActionResult AddMember(AddMemberRequestDTO memberRequestDto)
        {
            return Ok(_memberServices.AddMemberAsync(memberRequestDto));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateMemeber(UpdateMemberRequestDTO memberRequestDTO)
        {
            return Ok(_memberServices.UpdateMemberAsync(memberRequestDTO));
        }
    }
}

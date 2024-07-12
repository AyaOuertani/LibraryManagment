using LibraryManagment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Services;
using LibraryManagment.DTO.Requests;
using LibraryManagment.DTO.Responses;
namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrsController : ControllerBase
    {
        private readonly MemberServices _memberServices;
        
        public MembrsController(ApplicationDBcontext dbcontext)
        {
            _memberServices = new MemberServices(dbcontext);
        }
        
        [HttpGet]
        
        public IActionResult GetAllMemebrs() => Ok(_memberServices.GetAllMembers());
        
        [HttpGet]
        [Route("{id:int}")]

        public GetMemberByIdResponseDTO GetMemberById(int id)
        {
            var memberByIdRequestDTO = new GetMemberByIdRequestDTO { MemberID = id };
            return (_memberServices.GetMemberById(memberByIdRequestDTO));
            
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

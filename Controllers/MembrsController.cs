using LibraryManagment.DTOs.MembersDTOs;
using LibraryManagment.Interface;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Members
    public class MembrsController : ControllerBase
    {
        #region Variables + Constructor
        private readonly IMemberService _memberServices;

        public MembrsController(IMemberService memberService) => _memberServices = memberService;
        #endregion

        #region Get
        #region All
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10) => Ok(await _memberServices.GetAllAsync(pageNumber, pageSize));
        #endregion

        #region ById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _memberServices.GetByIdAsync(id));
        #endregion
        #endregion

        #region Post/Add
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddMemberRequest memberRequest)
        {
            return Ok(await _memberServices.AddAsync(memberRequest));
        }
        #endregion

        #region Put/Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateMemberRequest memberRequest)
        {
            return Ok(await _memberServices.UpdateAsync(memberRequest));
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return (await _memberServices.DeleteAsync(id)) ? Ok("Deleted Successfully") : NotFound("Failed To Delete");
        }
        #endregion
    }
    #endregion
}

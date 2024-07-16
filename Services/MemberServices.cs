using LibraryManagment.Data;
using LibraryManagment.DTO.Members.Requests;
using LibraryManagment.DTO.Members.Responses;
using LibraryManagment.Interface;
using LibraryManagment.Models;

namespace LibraryManagment.Services
{

    public class MemberServices : IMemberService
    {
        private readonly ApplicationDBcontext _dbcontext;

        public MemberServices(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Member> GetAllMembers() =>  _dbcontext.Members.ToList();

        public async Task<GetMemberByIdResponseDTO> GetMemberByIdAsync(GetMemberByIdRequestDTO memberByIdRequestDTO )
        {
            var member =await _dbcontext.Members.FindAsync(memberByIdRequestDTO.MemberID);
            if (member == null)
            {
                throw new KeyNotFoundException("Memeber Not Found");
            }
            return new GetMemberByIdResponseDTO {
                    Name = member.Name,
                    Age = member.Age,
                    Email = member.Email,
                    Phone   = member.Phone,
            } ;
        }

        public async Task<string> AddMemberAsync(AddMemberRequestDTO MemberRequestDto)
        {
            var Addmember = new Member()
            {
                Name = MemberRequestDto.Name,
                Age = MemberRequestDto.Age,
                Email = MemberRequestDto.Email,
                Phone = MemberRequestDto.Phone,
            };
            _dbcontext.Members.Add(Addmember);
            await _dbcontext.SaveChangesAsync();
            return ("Member added successfully !");
        }
        public async Task<string> UpdateMemberAsync(UpdateMemberRequestDTO memberRequestDTO)
        {
            var member = _dbcontext.Members.Find(memberRequestDTO.MemberID);
            if (member == null)
            {
                throw new KeyNotFoundException("Memeber Not Found");
            }

            member.Age = memberRequestDTO.Age;
            member.Email = memberRequestDTO.Email;
            member.Phone = memberRequestDTO.Phone;
            await _dbcontext.SaveChangesAsync();
            return ("Member update successfully !");
        }
        public async Task DeleteMemberAsync(DeleteMemberRequestDTO memberRequestDTO)
        {
            var member = await _dbcontext.Members.FindAsync(memberRequestDTO.MemberId);
            if (member is null)
            {
                throw new KeyNotFoundException("Member Not Found");
            }
            _dbcontext.Members.Remove(member);
            await _dbcontext.SaveChangesAsync();
        }
    }
}

using LibraryManagment.Data;
using LibraryManagment.DTO.Requests;
using LibraryManagment.DTO.Responses;
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

        public GetMemberByIdResponseDTO GetMemberById(GetMemberByIdRequestDTO memberByIdRequestDTO )
        {
            var member = _dbcontext.Members.Find(memberByIdRequestDTO.MemberID);
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
    }
}

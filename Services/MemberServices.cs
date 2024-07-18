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

        public List<Member> GetAll() =>  _dbcontext.Members.ToList();

        public async Task<GetMemberByIdResponse> GetByIdAsync(int id)
        {
            var member =await _dbcontext.Members.FindAsync(id);
            if (member == null)
            {
                throw new KeyNotFoundException("Memeber Not Found");
            }
            return new GetMemberByIdResponse {
                    Name = member.Name,
                    Age = member.Age,
                    Email = member.Email,
                    Phone   = member.Phone,
            } ;
        }

        public async Task<string> AddAsync(AddMemberRequest MemberRequest)
        {
            var Addmember = new Member()
            {
                Name = MemberRequest.Name,
                Age = MemberRequest.Age,
                Email = MemberRequest.Email,
                Phone = MemberRequest.Phone,
            };
            _dbcontext.Members.Add(Addmember);
            await _dbcontext.SaveChangesAsync();
            return ("Member added successfully !");
        }
        public async Task<string> UpdateAsync(UpdateMemberRequest memberRequest)
        {
            var member = _dbcontext.Members.Find(memberRequest.MemberID);
            if (member == null)
            {
                throw new KeyNotFoundException("Memeber Not Found");
            }

            member.Age = memberRequest.Age;
            member.Email = memberRequest.Email;
            member.Phone = memberRequest.Phone;
            await _dbcontext.SaveChangesAsync();
            return ("Member update successfully !");
        }
        public async Task<string> DeleteAsync(int id)
        {
            var member = await _dbcontext.Members.FindAsync(id);
            if (member is null)
            {
                throw new KeyNotFoundException("Member Not Found");
            }
            _dbcontext.Members.Remove(member);
            await _dbcontext.SaveChangesAsync();
            return ("Deleted Successfully");
        }
    }
}

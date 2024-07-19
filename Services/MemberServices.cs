using LibraryManagment.Data;
using LibraryManagment.DTOs.MembersDTOs.Requests;
using LibraryManagment.DTOs.MembersDTOs.Responses;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{

    public class MemberServices : IMemberService
    {
        private readonly ApplicationDBcontext _dbcontext;

        public MemberServices(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #region Get
        #region All
        public async Task<IEnumerable<GetAllMembersResponse>> GetAllAsync()
        {
            return (await _dbcontext.Members.Include(loan => loan.Loans)
                                            .Select(memberSelected => new GetAllMembersResponse(
                                                    memberSelected.MemberID,
                                                    memberSelected.Name,
                                                    memberSelected.Age,
                                                    memberSelected.Email,
                                                    memberSelected.Phone,
                                                    memberSelected.Loans.Select(loanSelected => loanSelected.Books.Title).ToList())
                                            ).ToListAsync());

        }
        #endregion
        #region ById
        public async Task<GetMemberByIdResponse> GetByIdAsync(int id)
        {
            Member? member = await _dbcontext.Members.FindAsync(id);
            return member == null
                ? throw new KeyNotFoundException("Memeber Not Found")
                : new GetMemberByIdResponse(
                      member.Name,
                      member.Age,
                      member.Email,
                      member.Phone
                );
        }
        #endregion
        #endregion
        #region Add
        public async Task<string> AddAsync(AddMemberRequest memberRequest)
        {
            _dbcontext.Members.Add(new Member(
                                              memberRequest.Name,
                                              memberRequest.Age,
                                              memberRequest.Email,
                                              memberRequest.Phone)
            );
            await _dbcontext.SaveChangesAsync();
            return ("Member added successfully !");
        }
        #endregion
        #region Update
        public async Task<string> UpdateAsync(UpdateMemberRequest memberRequest)
        {
            Member member = _dbcontext.Members.Find(memberRequest.MemberID)
                                              ?? throw new KeyNotFoundException("Memeber Not Found");
            member.Age = memberRequest.Age;
            member.Email = memberRequest.Email;
            member.Phone = memberRequest.Phone;
            await _dbcontext.SaveChangesAsync();
            return ("Member update successfully !");
        }
        #endregion
        #region Delete
        public async Task<string> DeleteAsync(int id)
        {
            Member? member = await _dbcontext.Members.FindAsync(id)
                                                     ?? throw new KeyNotFoundException("Member Not Found");
            _dbcontext.Members.Remove(member);
            await _dbcontext.SaveChangesAsync();
            return ("Deleted Successfully");
        }
        #endregion
    }
}

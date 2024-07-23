using LibraryManagment.Data;
using LibraryManagment.DTOs.MembersDTOs;
using LibraryManagment.Interface;
using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{

    public class MemberServices : IMemberService
    {
        #region Variable + Constroctor
        private readonly ApplicationDBcontext _dbcontext;

        public MemberServices(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Get

        #region All
        public async Task<IEnumerable<GetAllMemberResponse>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            return (await _dbcontext.Members.Include(loan => loan.Loans)
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .Select(memberSelected => new GetAllMemberResponse(memberSelected.MemberID,
                                                                                                memberSelected.Name,
                                                                                                memberSelected.Age,
                                                                                                memberSelected.Email,
                                                                                                memberSelected.Phone,
                                                                                                memberSelected.Loans.Select(loanSelected => loanSelected.Books.Title).ToList())).ToListAsync());

        }
        #endregion

        #region ById
        public async Task<GetMemberByIdResponse> GetByIdAsync(int id)
        {
            Member? member = await _dbcontext.Members.FindAsync(id);
            return member == null
                ? throw new KeyNotFoundException("Memeber Not Found")
                : new GetMemberByIdResponse(member.Name,
                                            member.Age,
                                            member.Email,
                                            member.Phone);
        }
        #endregion

        #endregion

        #region Add

        public async Task<bool> AddAsync(AddMemberRequest memberRequest)
        {
            _dbcontext.Members.Add(new Member
            {
                Name = memberRequest.Name,
                Age = memberRequest.Age,
                Email = memberRequest.Email,
                Phone = memberRequest.Phone
            });
            await _dbcontext.SaveChangesAsync();
            return (true);
        }

        #endregion

        #region Update
        public async Task<bool> UpdateAsync(UpdateMemberRequest memberRequest)
        {
            Member member = _dbcontext.Members.Find(memberRequest.MemberID)
                                              ?? throw new KeyNotFoundException("Memeber Not Found");
            if (memberRequest.Age.HasValue || memberRequest.Age != 0)
            {
                member.Age = memberRequest.Age.Value;
            }
            if (memberRequest.Email is null || memberRequest.Email == "string") {
                member.Email = member.Email;
            }
            else
            {
                member.Email = memberRequest.Email;
            }
            if (memberRequest.Phone is null || memberRequest.Phone == "string")
            {
                member.Phone = member.Phone;
            }
            else
            {
                member.Phone = memberRequest.Phone;
            }
            await _dbcontext.SaveChangesAsync();
            return (true);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(int id)
        {
            Member? member = await _dbcontext.Members.FindAsync(id)
                                                     ?? throw new KeyNotFoundException("Member Not Found");
            _dbcontext.Members.Remove(member);
            await _dbcontext.SaveChangesAsync();
            return (true);
        }
        #endregion
    }
}

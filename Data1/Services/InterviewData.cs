using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Data1.Contracts;
using Data1.Dtos;
using Microsoft.EntityFrameworkCore;
using Services.Data;

namespace Data1.Services
{
    public class InterviewData : IInterviewData
    {
        private readonly PersonalityContext _context;

        public InterviewData(PersonalityContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyInfoDto>> GetCompanies()
        {
            return await _context.Companies.ProjectTo<CompanyInfoDto>().ToListAsync();
        }

        public async Task<bool> CheckUser(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task AddUser(UserDetailsDto userData)
        {
            var user = new UserEntity {Email = userData.CandidateEmail, Name = userData.CandidateName};
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddProfile(string email, string analysis, string company)
        {
            var profile = new ProfileEntity()
            profile.UserId = userDataCandidateEmail;
            profile.CompanyId = company;
            profile.Analysis = analysis;

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }
    }
}

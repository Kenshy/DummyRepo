using System.Collections.Generic;
using System.Threading.Tasks;
using Data1.Dtos;
using Services.Data;

namespace Data1.Contracts
{
    public interface IInterviewData
    {
        Task<List<CompanyInfoDto>> GetCompanies();
        Task<bool> CheckUser(string userDataCandidateEmail);
        Task AddUser(UserDetailsDto userData);
        Task AddProfile(string email, string profile, string company);
    }
}

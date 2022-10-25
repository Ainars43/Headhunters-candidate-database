using System.Collections.Generic;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Interfaces
{
    public interface ICompaniesDataAccess : IEntityService<Company>
    {
        List<Company> GetAllCompanies();
        void DeleteCompany(int id);
    }
}

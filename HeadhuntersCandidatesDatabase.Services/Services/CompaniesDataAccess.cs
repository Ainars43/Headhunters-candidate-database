using System.Collections.Generic;
using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services.Services
{
    public class CompaniesDataAccess : EntityService<Company>, ICompaniesDataAccess
    {
        public CompaniesDataAccess(IHeadhuntersCandidatesDatabaseDbContext context) : base(context)
        {
        }

        public List<Company> GetAllCompanies()
        {
            return _context.CompaniesData.ToList();
        }

        public void DeleteCompany(int id)
        {
            var company = Query().SingleOrDefault(c => c.Id == id);
            if (company != null)
            {
                Delete(company);
            }
        }
    }
}

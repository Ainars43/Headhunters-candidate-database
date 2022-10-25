using HeadhuntersCandidatesDatabase.Data;
using System.Collections.Generic;
using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;
using HeadhuntersCandidatesDatabase.Services.Services;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CandidatesDataAccess : EntityService<Candidate>, ICandidatesDataAccess
    {
        public CandidatesDataAccess(IHeadhuntersCandidatesDatabaseDbContext context) : base(context)
        {
        }

        public List<Candidate> GetAllCandidates()
        {            
            return _context.CandidatesData.ToList();
        }

        public void DeleteCandidate(int id)
        {
            var candidate = Query().SingleOrDefault(c => c.Id == id);
            if (candidate != null)
            {
                Delete(candidate);
            }
        }
    }
}

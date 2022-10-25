using System.Collections.Generic;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Interfaces
{
    public interface ICandidatesDataAccess : IEntityService<Candidate>
    {
        List<Candidate> GetAllCandidates();
        void DeleteCandidate(int id);
    }
}

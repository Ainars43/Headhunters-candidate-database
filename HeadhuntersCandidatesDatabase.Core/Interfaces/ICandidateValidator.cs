using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Interfaces
{
    public interface ICandidateValidator
    {
        bool Validate(Candidate candidate);
    }
}
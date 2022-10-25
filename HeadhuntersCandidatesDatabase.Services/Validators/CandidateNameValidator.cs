using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Services.Validators
{
    public class CandidateNameValidator : ICandidateValidator
    {
        public bool Validate(Candidate candidate)
        {
            return !string.IsNullOrEmpty(candidate.Name);
        }
    }
}
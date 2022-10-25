using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Interfaces
{
    public interface ICompanyValidator
    {
        bool Validate(Company company);
    }
}
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Services.Validators
{
    public class CompanyNameValidator : ICompanyValidator
    {
        public bool Validate(Company company)
        {
            return !string.IsNullOrEmpty(company.Name);
        }
    }
}
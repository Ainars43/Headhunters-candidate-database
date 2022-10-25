using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Services.Validators
{
    internal class CandidateSurnameValidator : ICandidateValidator
    {
        public bool Validate(Candidate candidate)
        {
            return !string.IsNullOrEmpty(candidate.Surname);
        }
    }
}

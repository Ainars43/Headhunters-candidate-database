using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public virtual List<Positions> CompanyPositions { get; set; }
        public virtual List<Candidate> Candidates { get; set; }
    }
}

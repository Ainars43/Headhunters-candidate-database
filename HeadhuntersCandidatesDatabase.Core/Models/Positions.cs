using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class Positions : Entity
    {
        public string Position{ get; set; }
        public virtual List<Candidate> Candidates { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}
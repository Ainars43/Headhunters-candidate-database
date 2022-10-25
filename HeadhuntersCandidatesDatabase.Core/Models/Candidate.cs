using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class Candidate : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual List<Company> CompaniesAppliedFor { get; set; }
        public List<Skill> SkillSet { get; set; }
    }
}

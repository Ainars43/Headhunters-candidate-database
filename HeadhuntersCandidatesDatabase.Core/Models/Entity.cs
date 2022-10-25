using HeadhuntersCandidatesDatabase.Core.Interfaces;

namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}

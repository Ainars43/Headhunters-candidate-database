using HeadhuntersCandidatesDatabase.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Core.Interfaces
{
    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> Query();
        IEnumerable<T> Get();
        T GetByID(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Data;
using System.Collections.Generic;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Services.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IHeadhuntersCandidatesDatabaseDbContext context) : base(context)
        {
        }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public T GetByID(int id)
        {
            return GetByID<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }
    }
}

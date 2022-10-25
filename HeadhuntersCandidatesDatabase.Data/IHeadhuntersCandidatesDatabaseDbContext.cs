using System.Threading.Tasks;
using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeadhuntersCandidatesDatabase.Data
{
    public interface IHeadhuntersCandidatesDatabaseDbContext
    {
        DbSet<Candidate> CandidatesData { get; set; }
        DbSet<Company> CompaniesData { get; set; }

        DbSet<Positions> Positions { get; set; }
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

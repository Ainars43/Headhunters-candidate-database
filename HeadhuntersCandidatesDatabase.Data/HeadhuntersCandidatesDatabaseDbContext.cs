using System.Threading.Tasks;
using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Data
{
    public class HeadhuntersCandidatesDatabaseDbContext : DbContext, IHeadhuntersCandidatesDatabaseDbContext
    {  
        public HeadhuntersCandidatesDatabaseDbContext(DbContextOptions options) :
            base(options) { }

        public DbSet<Candidate> CandidatesData { get; set; }
        public DbSet<Company> CompaniesData { get; set; }
        public DbSet<Positions> Positions { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}

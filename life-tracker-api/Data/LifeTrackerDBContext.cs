using LifeTracker.Data;
using LifeTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LifeTrackerDBContext: DbContext, ILifeTrackerDBContext
    {
        public LifeTrackerDBContext(DbContextOptions<LifeTrackerDBContext> contextOptions): base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserEntity> Users { get; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

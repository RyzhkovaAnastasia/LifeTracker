using LifeTracker.Data;
using LifeTracker.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LifeTrackerDBContext : IdentityDbContext<UserEntity>, ILifeTrackerDBContext
    {
        public DbSet<UserEntity> Accounts { get; set; }

        public LifeTrackerDBContext(DbContextOptions<LifeTrackerDBContext> contextOptions): base(contextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}

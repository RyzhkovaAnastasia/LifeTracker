using LifeTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Data
{
    public interface ILifeTrackerDBContext
    {
        public DbSet<UserEntity> Accounts { get; set; }
    }
}

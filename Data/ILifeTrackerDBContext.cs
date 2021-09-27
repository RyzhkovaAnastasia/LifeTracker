using LifeTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Data
{
    public interface ILifeTrackerDBContext
    {
        DbSet<UserEntity> Users { get; set; }
    }
}

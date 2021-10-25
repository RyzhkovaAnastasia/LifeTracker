using LifeTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LifeTracker.Data
{
    public interface ILifeTrackerDBContext
    {
        public DbSet<UserEntity> Accounts { get; set; }
        public DbSet<RewardEntity> Rewards { get; set; }
        public DbSet<ToDoEntity> ToDos { get; set; }
        public DbSet<HabitEntity> Habits { get; set; }
        public DbSet<DailyEntity> Dailies { get; set; }
        public DbSet<TagEntity> Tags { get; set; }

        int SaveChanges();
        EntityEntry Entry(object entity);
    }
}

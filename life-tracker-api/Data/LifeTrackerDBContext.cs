using LifeTracker.Data;
using LifeTracker.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LifeTrackerDBContext : IdentityDbContext<UserEntity>, ILifeTrackerDBContext
    {
        public DbSet<UserEntity> Accounts { get; set; }
        public DbSet<RewardEntity> Rewards { get; set; }
        public DbSet<ToDoEntity> ToDos { get; set; }
        public DbSet<HabitEntity> Habits { get; set; }
        public DbSet<DailyEntity> Dailies { get; set; }
        public DbSet<TagEntity> Tags { get; set; }

        public LifeTrackerDBContext(DbContextOptions<LifeTrackerDBContext> contextOptions) : base(contextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region userEntity

            var userModelBuilder = builder.Entity<UserEntity>();
            userModelBuilder
                .Property(user => user.Money)
                .HasDefaultValue(decimal.Zero);
            #endregion
            #region RewardEntity
            var rewardsModelBuilder = builder.Entity<RewardEntity>();
            rewardsModelBuilder
                .HasKey(reward => reward.Id);

            rewardsModelBuilder
                .Property(reward => reward.Title)
                .IsRequired()
                .HasMaxLength(100);

            rewardsModelBuilder
                .Property(reward => reward.Note)
                .HasMaxLength(1000);

            rewardsModelBuilder
                .HasOne(reward => reward.User)
                .WithMany(reward => reward.Rewards)
                .HasForeignKey(reward => reward.UserId)
                .IsRequired();
            #endregion
            #region HabitEntity
            var habitModelBuilder = builder.Entity<HabitEntity>();
            habitModelBuilder
                .HasKey(habit => habit.Id);

            habitModelBuilder
                .Property(habit => habit.Title)
                .IsRequired()
                .HasMaxLength(100);

            habitModelBuilder
                .Property(habit => habit.Note)
                .HasMaxLength(1000);

            habitModelBuilder
                .HasOne(u => u.User)
                .WithMany(habit => habit.Habits)
                .HasForeignKey(habit => habit.UserId)
                .IsRequired();
            #endregion
            #region ToDoEntity
            var todoModelBuilder = builder.Entity<ToDoEntity>();
            todoModelBuilder
                .HasKey(todo => todo.Id);

            todoModelBuilder
                .Property(todo => todo.IsComplete)
                .HasDefaultValue(false);

            todoModelBuilder
                .Property(todo => todo.Title)
                .IsRequired()
                .HasMaxLength(100);

            todoModelBuilder
                .Property(todo => todo.Note)
                .HasMaxLength(1000);

            todoModelBuilder
                .HasOne(u => u.User)
                .WithMany(todo => todo.ToDos)
                .HasForeignKey(todo => todo.UserId)
                .IsRequired();
            #endregion
            #region DailyEntity
            var dailyModelBuilder = builder.Entity<DailyEntity>();
            dailyModelBuilder
                .HasKey(daily => daily.Id);

            dailyModelBuilder
                .Property(daily => daily.IsComplete)
                .HasDefaultValue(false);

            dailyModelBuilder
                .Property(daily => daily.Title)
                .IsRequired()
                .HasMaxLength(100);

            dailyModelBuilder
                .Property(daily => daily.Note)
                .HasMaxLength(1000);

            dailyModelBuilder
                .HasOne(u => u.User)
                .WithMany(daily => daily.Dailies)
                .HasForeignKey(daily => daily.UserId)
                .IsRequired();
            #endregion
            #region TagEntity
            var tagModelBuilder = builder.Entity<TagEntity>();
            #endregion
            #region ItemTagsEntity
            var itemTagModelBuilder = builder.Entity<ItemTagsEntity>();
            #endregion
            #region SubtaskEntity
            var subtaskTagModelBuilder = builder.Entity<SubtaskEntity>();
            #endregion
            #region ItemSubtaskEntity
            var itemSubtaskTagModelBuilder = builder.Entity<ItemSubtaskEntity>();
            #endregion
        }
    }
}

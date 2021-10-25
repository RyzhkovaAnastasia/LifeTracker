using LifeTracker.Data;
using LifeTracker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class LifeTrackerDBContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>, ILifeTrackerDBContext
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
                .Property(user => user.Currency)
                .HasDefaultValue(10m);
            #endregion
            #region RewardEntity
            var rewardsModelBuilder = builder.Entity<RewardEntity>();

            rewardsModelBuilder
                .Property(reward => reward.Title)
                .IsRequired()
                .HasMaxLength(100);

            rewardsModelBuilder
               .Property(reward => reward.Cost)
               .IsRequired();

            rewardsModelBuilder
               .Property(reward => reward.ItemType)
               .IsRequired();

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
                .Property(habit => habit.Title)
                .IsRequired()
                .HasMaxLength(100);

            habitModelBuilder
                .Property(habit => habit.Note)
                .HasMaxLength(1000);

            habitModelBuilder
                .Property(habit => habit.Date)
                .HasDefaultValueSql("getdate()");

            habitModelBuilder
                .Property(habit => habit.Difficulty)
                .IsRequired();

            habitModelBuilder
                .Property(habit => habit.ItemType)
                .IsRequired();

            habitModelBuilder
                .Property(habit => habit.Strike)
                .HasDefaultValue(0);

            habitModelBuilder
                .HasOne(u => u.User)
                .WithMany(habit => habit.Habits)
                .HasForeignKey(habit => habit.UserId)
                .IsRequired();
            #endregion
            #region ToDoEntity
            var todoModelBuilder = builder.Entity<ToDoEntity>();

            todoModelBuilder
                .Property(todo => todo.IsComplete)
                .HasDefaultValue(false)
                .IsRequired();

            todoModelBuilder
                .Property(todo => todo.Date)
                .HasDefaultValueSql("getdate()");

            todoModelBuilder
               .Property(todo => todo.Difficulty)
               .IsRequired();

            todoModelBuilder
              .Property(todo => todo.ItemType)
              .IsRequired();

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
                .Property(daily => daily.IsComplete)
                .HasDefaultValue(false);

            dailyModelBuilder
               .Property(daily => daily.Date)
               .HasDefaultValueSql("getdate()");

            dailyModelBuilder
               .Property(daily => daily.EndDate)
               .HasDefaultValueSql("getdate()");

            dailyModelBuilder
               .Property(daily => daily.Difficulty)
               .IsRequired();

            dailyModelBuilder
               .Property(daily => daily.ItemType)
               .IsRequired();

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

            builder
                .HasSequence<int>("SeriesId_seq")
                .StartsAt(1)
                .IncrementsBy(1);

            dailyModelBuilder
              .Property(daily => daily.SeriesId)
              .HasDefaultValueSql("NEXT VALUE FOR SeriesId_seq");


            #endregion
            #region TagEntity
            var tagModelBuilder = builder.Entity<TagEntity>();

            tagModelBuilder
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            #endregion
            #region ItemTagsEntity
            var itemTagModelBuilder = builder.Entity<ItemTagsEntity>();

            itemTagModelBuilder
                .HasKey(i => new
                {
                    i.ItemType,
                    i.ItemId,
                    i.TagId
                });

            //itemTagModelBuilder
            //.HasOne(i => i.ItemType)
            //.WithMany(t => t.Tags)
            //.HasForeignKey(ii => ii.ItemId);

            itemTagModelBuilder
            .HasOne(t => t.Tag)
            .WithMany(i => i.Items)
            .HasForeignKey(ti => ti.TagId);

            #endregion
            #region ToDoSubtaskEntity
            var subtaskTagModelBuilder = builder.Entity<ToDoSubtaskEntity>();

            subtaskTagModelBuilder
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            subtaskTagModelBuilder
                .Property(s => s.IsComplete)
                .HasDefaultValue(false)
                .IsRequired();

            subtaskTagModelBuilder
                .HasOne(ci => ci.ToDo)
                .WithMany(s => s.Subtasks)
                .HasForeignKey(cii => cii.ToDoId);

            #endregion
            #region DailySubtaskEntity
            var dailySubtaskTagModelBuilder = builder.Entity<DailySubtaskEntity>();

            dailySubtaskTagModelBuilder
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            dailySubtaskTagModelBuilder
                .Property(s => s.IsComplete)
                .HasDefaultValue(false)
                .IsRequired();

            dailySubtaskTagModelBuilder
                .HasOne(ci => ci.Daily)
                .WithMany(s => s.Subtasks)
                .HasForeignKey(cii => cii.DailyId);

            #endregion
        }
    }
}

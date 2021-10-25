using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public decimal? Currency { set; get; }
        public List<RewardEntity> Rewards { get; set; }
        public List<HabitEntity> Habits { get; set; }
        public List<ToDoEntity> ToDos { get; set; }
        public List<DailyEntity> Dailies { get; set; }

        public UserEntity() : base()
        {
            Rewards = new List<RewardEntity>();
            Habits = new List<HabitEntity>();
            ToDos = new List<ToDoEntity>();
            Dailies = new List<DailyEntity>();
        }
    }
}


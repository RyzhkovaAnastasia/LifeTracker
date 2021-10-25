using LifeTracker.Business.ViewModels;
using System;
using System.Collections.Generic;

namespace LifeTracker.Business.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal? Currency { get; set; }
        public List<RewardViewModel> Rewards { get; set; }
        public List<HabitViewModel> Habits { get; set; }
        public List<ToDoViewModel> ToDos { get; set; }
        public List<DailyViewModel> Dailies { get; set; }
    }
}

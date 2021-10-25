using Enums;
using System;
using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class HabitEntity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public ItemType ItemType { get; set; }
        public List<ItemTagsEntity> Tags { get; set; }
        public bool? IsEncouragment { get; set; }
        public bool? IsPunisment { get; set; }
        public int Strike { get; set; }
        public DateTime Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public Reiteration Reiteration { get; set; }

        public HabitEntity()
        {
            Tags = new List<ItemTagsEntity>();
        }
    }
}

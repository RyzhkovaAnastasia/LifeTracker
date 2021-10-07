using Enums;
using System;

namespace LifeTracker.Data.Entities
{
    public class HabitEntity: ItemEntity
    {
        public bool IsEncouragment { get; set; }
        public bool IsPunisment { get; set; }
        public int Strike { get; set; }
        public DateTime Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public Reiteration Reiteration { get; set; }

        public HabitEntity(): base() { }
    }
}

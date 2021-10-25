using Enums;
using System;

namespace LifeTracker.Business.ViewModels
{
    public class HabitViewModel: ItemViewModel
    {
        public bool? IsEncouragment { get; set; }
        public bool? IsPunisment { get; set; }
        public int Strike { get; set; }
        public DateTime Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public Reiteration Reiteration { get; set; }
    }
}

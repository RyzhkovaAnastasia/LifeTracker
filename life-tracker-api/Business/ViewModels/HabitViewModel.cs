using Enums;
using System;
using System.Collections.Generic;
using System.Text;

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

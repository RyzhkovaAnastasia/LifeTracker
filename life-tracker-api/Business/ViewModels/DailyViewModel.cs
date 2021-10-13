using Enums;
using System;

namespace LifeTracker.Business.ViewModels
{
    public class DailyViewModel: ItemViewModel
    {
        public Reiteration Reiteration { get; set; }
        public DateTime EndDate { get; set; }
    }
}

using Enums;
using System;

namespace LifeTracker.Data.Entities
{
    public class DailyEntity : ComplexItemEntity
    {
        public int? SeriesId { get; set; }
        public Reiteration Reiteration { get; set; }
        public DateTime EndDate { get; set; }

        public DailyEntity(): base() { }
    }
}

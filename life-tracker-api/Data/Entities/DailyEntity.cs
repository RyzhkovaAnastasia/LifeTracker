using Enums;

namespace LifeTracker.Data.Entities
{
    public class DailyEntity : ComplexItemEntity
    {
        public Reiteration Reiteration { get; set; }

        public DailyEntity(): base() { }
    }
}

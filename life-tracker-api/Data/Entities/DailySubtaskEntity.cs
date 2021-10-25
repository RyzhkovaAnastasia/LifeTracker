namespace LifeTracker.Data.Entities
{
    public class DailySubtaskEntity
    {
        public int Id { get;  set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
        public int DailyId { get; set; }
        public DailyEntity Daily { get; set; }
    }
}

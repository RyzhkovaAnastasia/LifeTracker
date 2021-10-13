namespace LifeTracker.Data.Entities
{
    public class SubtaskEntity
    {
        public int Id { get;  set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
        public int ComplexItemsId { get; set; }
        public ComplexItemEntity ComplexItems { get; set; }
    }
}

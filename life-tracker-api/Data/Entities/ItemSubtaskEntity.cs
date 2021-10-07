using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class ItemSubtaskEntity
    {
        public SubtaskEntity Subtask { get; set; }
        public int SubtaskId { get; set; }
        public ComplexItemEntity ComplexItem { get; set; }
        public int ComplexItemId { get; set; }
    }
}

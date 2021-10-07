using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class SubtaskEntity
    {
        public int Id { get;  set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }

        public List<ComplexItemEntity> ComplexItems { get; set; }

        public SubtaskEntity()
        {
            ComplexItems = new List<ComplexItemEntity>();
        }
    }
}

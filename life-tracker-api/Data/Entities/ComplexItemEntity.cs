using Enums;
using System;
using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class ComplexItemEntity : ItemEntity
    {
        public bool IsComplete { get; set; }
        public DateTime? Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<SubtaskEntity> Subtasks { get; set; }
        public ComplexItemEntity() : base()
        {
            Subtasks = new List<SubtaskEntity>();
        }
    }
}

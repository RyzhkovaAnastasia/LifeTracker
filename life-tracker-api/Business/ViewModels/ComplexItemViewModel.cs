using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Business.ViewModels
{
    public abstract class ComplexItemViewModel : ItemViewModel
    {
        public bool IsComplete { get; set; }
        public DateTime Date { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<SubtaskViewModel> Subtasks { get; set; }
    }
}

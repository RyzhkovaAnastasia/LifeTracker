using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Business.ViewModels
{
    public class SubtaskViewModel
    {
        public int Id { get; set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
        public ComplexItemViewModel ComplexItemsId { get; set; }
    }
}

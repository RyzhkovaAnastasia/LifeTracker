using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Business.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}

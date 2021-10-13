using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Business.ViewModels
{
    public abstract class ItemViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public ItemType ItemType { get; set; }
        public List<TagsViewModel> Tags { get; set; }
    }
}

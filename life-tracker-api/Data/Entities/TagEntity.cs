using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ItemTagsEntity> Items { get; set; } 

        public TagEntity()
        {
            Items = new List<ItemTagsEntity>();
        }
    }
}

using Enums;
using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public abstract class ItemEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public ItemType ItemType { get; set; }
        public List<ItemTagsEntity> Tags { get; set; }
        public ItemEntity()
        {
            Tags = new List<ItemTagsEntity>();
        }
    }
}

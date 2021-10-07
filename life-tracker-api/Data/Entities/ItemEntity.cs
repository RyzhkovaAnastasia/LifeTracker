using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public List<TagEntity> Tags { get; set; }
        public ItemEntity()
        {
            Tags = new List<TagEntity>();
        }
    }
}

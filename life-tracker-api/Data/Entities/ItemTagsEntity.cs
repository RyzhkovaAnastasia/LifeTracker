using Enums;

namespace LifeTracker.Data.Entities
{
    public class ItemTagsEntity
    {
        public TagEntity Tag { get; set; }
        public int TagId { get; set; }
        public ItemType ItemType{ get; set; }
        public int ItemId { get; set; }
    }
}

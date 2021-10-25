using Enums;
using System;
using System.Collections.Generic;

namespace LifeTracker.Data.Entities
{
    public class RewardEntity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public decimal Cost { get; set; }
        public ItemType ItemType { get; set; }
        public List<ItemTagsEntity> Tags { get; set; }
        protected RewardEntity()
        {
            Tags = new List<ItemTagsEntity>();
        }
        
    }
}

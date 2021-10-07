namespace LifeTracker.Data.Entities
{
    public class RewardEntity: ItemEntity
    {
        public decimal Cost { get; set; }
        public RewardEntity(): base() { }
    }
}

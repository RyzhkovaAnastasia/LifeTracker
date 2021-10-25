using LifeTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeTracker.Data.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly ILifeTrackerDBContext _context;
        public RewardRepository(ILifeTrackerDBContext context)
        {
            _context = context;
        }
        public void Create(RewardEntity item)
        {
            _context.Rewards.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Rewards.Remove(Get(id));
            _context.SaveChanges();
        }

        public RewardEntity Get(int id)
        {
            return _context.Rewards.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<RewardEntity> GetAll(Guid userId)
        {
            return _context.Rewards.ToList();
        }

        public void Update(RewardEntity item)
        {
            _context.Rewards.Update(item);
            _context.SaveChanges();
        }
    }
}

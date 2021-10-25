using LifeTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeTracker.Data.Repositories
{
    public class DailyRepository : IDailyRepository
    {
        private readonly ILifeTrackerDBContext _context;
        public DailyRepository(ILifeTrackerDBContext context) 
        {
            _context = context;
        }
        public void Create(DailyEntity item)
        {
            _context.Dailies.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Dailies.FirstOrDefault(x => x.Id == id);
            _context.Dailies.Remove(item);
            _context.SaveChanges();
        }

        public DailyEntity Get(int id)
        {
            return _context.Dailies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DailyEntity> GetAll(Guid userId)
        {
            return _context.Dailies.Where(x=>x.UserId == userId).ToList();
        }

        public void Update(DailyEntity item)
        {
            _context.Dailies.Update(item);
            _context.SaveChanges();
        }
    }
}

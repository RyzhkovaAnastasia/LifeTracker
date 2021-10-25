using LifeTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeTracker.Data.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly ILifeTrackerDBContext _context;
        public HabitRepository(ILifeTrackerDBContext context)
        {
            _context = context;
        }
        public void Create(HabitEntity item)
        {
            _context.Habits.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Habits.Add(Get(id));
            _context.SaveChanges();
        }

        public HabitEntity Get(int id)
        {
            return _context.Habits.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<HabitEntity> GetAll(Guid userId)
        {
            return _context.Habits.ToList();
        }

        public void Update(HabitEntity item)
        {
            _context.Habits.Update(item);
            _context.SaveChanges();
        }
    }
}

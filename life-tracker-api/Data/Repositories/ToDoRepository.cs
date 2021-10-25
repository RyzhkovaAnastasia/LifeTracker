using LifeTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeTracker.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ILifeTrackerDBContext _context;

        public ToDoRepository(ILifeTrackerDBContext context)
        {
            _context = context;
        }

        public void Create(ToDoEntity item)
        {
            _context.ToDos.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.ToDos.Remove(Get(id));
            _context.SaveChanges();
        }

        public ToDoEntity Get(int id)
        {
            return _context.ToDos.FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<ToDoEntity> GetAll(Guid userId)
        {
            return _context.ToDos.ToList();
        }

        public void Update(ToDoEntity item)
        {
            _context.ToDos.Update(item);
            _context.SaveChanges();
        }
    }
}

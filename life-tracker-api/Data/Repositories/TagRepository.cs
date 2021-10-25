using LifeTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeTracker.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ILifeTrackerDBContext _context;

        public TagRepository(ILifeTrackerDBContext context)
        {
            _context = context;
        }
        public void Create(TagEntity item)
        {
            _context.Tags.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Tags.Remove(Get(id));
            _context.SaveChanges();
        }

        public TagEntity Get(int id)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TagEntity> GetAll(Guid userId)
        {
            return _context.Tags.ToList();
        }

        public void Update(TagEntity item)
        {
            _context.Tags.Update(item);
            _context.SaveChanges();
        }
    }
}

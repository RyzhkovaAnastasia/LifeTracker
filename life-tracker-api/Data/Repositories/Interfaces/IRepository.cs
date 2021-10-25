using System;
using System.Collections.Generic;

namespace LifeTracker.Data.Repositories.Interfaces
{
    public interface IRepository<BaseEntity> where BaseEntity : class
    {
        IEnumerable<BaseEntity> GetAll(Guid userId);
        BaseEntity Get(int id);
        void Create(BaseEntity item);
        void Update(BaseEntity item);
        void Delete(int id);
    }
}

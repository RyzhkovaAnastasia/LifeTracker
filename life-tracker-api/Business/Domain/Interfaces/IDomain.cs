using System;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IDomain<BaseModel> where BaseModel : class
    {
        IEnumerable<BaseModel> GetAll(Guid userId);
        BaseModel Get(int id);
        void Create(BaseModel item, Guid userId);
        void Update(BaseModel item, Guid userId);
        void Delete(int id, Guid userId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Data.Repositories
{
    public class RewardRepository
    {
        readonly ILifeTrackerDBContext _contex;
        public RewardRepository(ILifeTrackerDBContext context)
        {
            _contex = context;
        }


    }
}

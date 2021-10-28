using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Data.Entities
{
    public class LogEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
    }
}

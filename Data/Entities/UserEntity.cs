using System;
using System.Collections.Generic;
using System.Text;

namespace LifeTracker.Data.Entities
{
    public class UserEntity
    {
        int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
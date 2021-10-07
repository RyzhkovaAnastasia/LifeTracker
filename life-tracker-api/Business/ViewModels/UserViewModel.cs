using Microsoft.AspNetCore.Identity;

namespace LifeTracker.Business.Models
{
    public class UserViewModel: IdentityUser
    {
        public decimal Money { get; set; }
    }
}

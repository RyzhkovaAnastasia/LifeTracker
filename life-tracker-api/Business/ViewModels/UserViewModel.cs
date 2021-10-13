using Microsoft.AspNetCore.Identity;

namespace LifeTracker.Business.Models
{
    public class UserViewModel: IdentityUser
    {
        public decimal? Currency { get; set; }
    }
}

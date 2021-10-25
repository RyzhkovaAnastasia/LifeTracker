using LifeTracker.Business.Models;

namespace LifeTracker.Business.ViewModels
{
    public class UserAuthenticatedViewModel : UserViewModel
    {
        public string JWT { get; set; }
    }
}

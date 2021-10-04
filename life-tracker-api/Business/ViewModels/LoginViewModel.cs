using System.ComponentModel.DataAnnotations;

namespace LifeTracker.Business.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string EmailOrUsername { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LifeTracker.Business.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "It is not match the password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace CarStore.BusinessLogicLayer.Models.Account
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

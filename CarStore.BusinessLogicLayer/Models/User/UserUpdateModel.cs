

using CarStore.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStore.BusinessLogicLayer.Models.User
{
    public class UserUpdateModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }

        public List<Transport> Transports { get; set; }
    }
}

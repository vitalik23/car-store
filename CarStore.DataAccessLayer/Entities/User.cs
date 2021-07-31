using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStore.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string RefreshToken { get; set; }

        public List<Transport> Transports { get; set; }
        public User()
        {
            Transports = new List<Transport>();
        }
    }
}

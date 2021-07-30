using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarStore.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; }

        public List<Transport> Transports { get; set; }
        public User()
        {
            Transports = new List<Transport>();
        }
    }
}

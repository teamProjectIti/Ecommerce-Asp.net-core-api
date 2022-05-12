using System;

namespace WebApplication1.Model.ViewModelIdentity
{
    public class AuthResultVM
    {
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}

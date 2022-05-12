using Microsoft.AspNetCore.Identity;

namespace WebApplication1
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string City { get; set; }
        public string Image { get; set; }

    }
}

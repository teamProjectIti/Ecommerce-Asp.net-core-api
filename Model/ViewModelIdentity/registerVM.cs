using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.ViewModelIdentity
{
    public class registerVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string emailAddress { get; set; }
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

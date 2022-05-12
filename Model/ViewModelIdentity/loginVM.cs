using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.ViewModelIdentity
{
    public class loginVM
    {
        [Required]
        public string emailAddress { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}

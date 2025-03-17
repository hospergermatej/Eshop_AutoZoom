using System.ComponentModel.DataAnnotations;

namespace REAL_EshopProjectHosperger.Models.Auth
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(64)]
        
        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        
        public string Password { get; set; }

        [Required]
        [MaxLength(128)]
        
        public string Firstname { get; set; }
        
        [Required]

        [MaxLength(128)]
        public string Lastname { get; set; }

        [MaxLength(128)]
        public string? Email { get; set; }

        public RegisterViewModel()
        {
            Username = string.Empty;
            Password = string.Empty;
            Firstname = string.Empty;
            Lastname = string.Empty;
            
        }
    }
}

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
        [RegularExpression("@^[a-zA-Z0-9._-]{3,20}$")]
        public string Password { get; set; }

        [Required]
        [MaxLength(128)]
        [RegularExpression("^[A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ][a-záčďéěíňóřšťúůýž]{1,49}$")]
        public string Firstname { get; set; }
        
        [Required]
        [RegularExpression("^[A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ][a-záčďéěíňóřšťúůýž]{1,49}$")]
        [MaxLength(128)]
        public string Lastname { get; set; }

        [RegularExpression("@^[a-zA-Z0-9]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
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

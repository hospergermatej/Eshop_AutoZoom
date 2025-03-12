using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace REAL_EshopProjectHosperger.Entities
{
    [Table("account")]
    public class Account
    {
        
        [Column("id")]
        public int ID { get; set; }
        [Column("username")]
        public string Username { get; set; }
        
        [Column("password")]
        public string Password { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("email")]
        public string? Email { get; set; }

        public Account() 
        { 
            ID = 0;
            Username = string.Empty;
            Password = string.Empty;
            Role = "user";
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }

        public Account(int id, string username, string password, string role, string firstName, string lastName, string? email)
        {
            ID = id;
            Username = username;
            Password = password;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}

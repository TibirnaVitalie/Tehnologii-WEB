using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Models
{
     public class UserLogin
     {
          [Required]
          [Display(Name = "Username or Email")]
          public string Username { get; set; }

          [Required]
          [DataType(DataType.Password)]
          [Display(Name = "Password")]
          public string Password { get; set; }
     }
}
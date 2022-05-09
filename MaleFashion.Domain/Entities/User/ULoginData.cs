using System;

namespace MaleFashion.Domain.Entities.User
{
     public class ULoginData
     {
          public string Username { get; set; }
          public string Password { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }
     }
}

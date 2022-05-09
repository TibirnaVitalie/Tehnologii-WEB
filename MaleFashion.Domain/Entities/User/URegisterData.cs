using System;
using MaleFashion.Domain.Enums;

namespace MaleFashion.Domain.Entities.User
{
     public class URegisterData
     {
          public string Username { get; set; }
          public string Password { get; set; }
          public string Email { get; set; }
          public DateTime RegisterDate { get; set; }
          public DateTime LoginDateTime { get; set; }
          public string LoginIp { get; set; }
          public URole Level { get; set; }
          public int CartProducts { get; set; }
     }
}

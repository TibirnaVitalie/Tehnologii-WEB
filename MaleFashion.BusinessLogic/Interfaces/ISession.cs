using System.Web;
using MaleFashion.Domain.Entities.User;

namespace MaleFashion.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
          HttpCookie GenCookie(string loginCredential);
          URegisterResp UserRegister(URegisterData data);
          UserMinimal GetUserByCookie(string apiCookieValue);
     }
}

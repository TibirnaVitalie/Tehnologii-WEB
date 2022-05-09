using System.Web;
using MaleFashion.BusinessLogic.Core;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.Domain.Entities.User;

namespace MaleFashion.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }

          public URegisterResp UserRegister(URegisterData data)
          {
               return UserRegisterAction(data);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
              return UserCookie(apiCookieValue);
          }
     }
}

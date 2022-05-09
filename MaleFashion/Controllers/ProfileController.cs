using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaleFashion.Web.App_Start;
using MaleFashion.Web.Extension;
using MaleFashion.Domain.Entities.User;

namespace MaleFashion.Web.Controllers
{
    public class ProfileController : BaseController
    {
          // GET: Profile
          [UserMod]
          public ActionResult UserProfile()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserMinimal um = new UserMinimal
                    {
                         Id = user.Id,
                         Username = user.Username,
                         Email = user.Email,
                         LastLogin = user.LastLogin,
                         LasIp = user.LasIp,
                         Level = user.Level,
                         CartProducts = user.CartProducts
                    };
                    return View(um);
               }
               else
               {
                    return View();
               }
          }

          /*[UserMod]
          public ActionResult UserProfile()
          {
               return View("Profile");
          }*/
          public ActionResult Logout()
          {
               SessionStatus();
               System.Web.HttpContext.Current.Session.Clear();
               if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
               {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         cookie.Expires = DateTime.Now.AddDays(-1);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
               }
               System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
               return View();
          }
    }
}
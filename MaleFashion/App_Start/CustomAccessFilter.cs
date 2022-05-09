using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MaleFashion.BusinessLogic;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.Web.Extension;
using MaleFashion.Domain.Enums;

namespace MaleFashion.Web.App_Start
{
     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
     public class NoDirectAccessCustomAccesFilter : ActionFilterAttribute
     {
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               if (filterContext.HttpContext.Request.Url != null &&
               (filterContext.HttpContext.Request.UrlReferrer == null ||
               filterContext.HttpContext.Request.Url.Host !=
               filterContext.HttpContext.Request.UrlReferrer.Host))
               {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                         controller = "Error",
                         action =
                    "Error500"
                    }));
               }
          }
     }
     public class AdminModAttribute : ActionFilterAttribute
     {
          private ISession _session;
          public AdminModAttribute()
          {
               var bl = new MyBusinessLogic();
               _session = bl.GetSessionBL();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var adminSession = HttpContext.Current.GetMySessionObject();
               if (adminSession != null)
               {
                    var cookie = HttpContext.Current.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         var profile = _session.GetUserByCookie(cookie.Value);
                         if (profile != null && profile.Level == URole.Admin)
                         {
                              HttpContext.Current.SetMySessionObject(profile);
                         }
                         else
                         {
                              filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                         }
                    }
                    else
                    {
                         filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                    }
               }
               else
               {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
               }
          }
     }

     public class UserModAttribute : ActionFilterAttribute
     {
          private readonly ISession _session;
          public UserModAttribute()
          {
               var bl = new MyBusinessLogic();
               _session = bl.GetSessionBL();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var userSession = HttpContext.Current.GetMySessionObject();
               if (userSession != null)
               {
                    var cookie = HttpContext.Current.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         var profile = _session.GetUserByCookie(cookie.Value);
                         if (profile != null && (profile.Level == URole.User || profile.Level == URole.Moderator))
                         {
                              HttpContext.Current.SetMySessionObject(profile);
                         }
                         else
                         {
                              filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                         }
                    }
                    else
                    {
                         filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                    }
               }
               else
               {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
               }
          }
     }
}
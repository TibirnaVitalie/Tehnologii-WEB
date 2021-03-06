using System;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Domain.Entities.User;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.BusinessLogic;
using MaleFashion.Web.Models;

namespace MaleFashion.Web.Controllers
{
    public class SignInController : Controller
    {
          private readonly ISession _session;
          public SignInController()
          {
               var bl = new MyBusinessLogic();
               _session = bl.GetSessionBL();
          }

          // GET: Login
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    ULoginData data = new ULoginData
                    {
                         Username = login.Username,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now
                    };

                    ULoginResp userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(login.Username);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }

               }

               return View();
          }
     }
}
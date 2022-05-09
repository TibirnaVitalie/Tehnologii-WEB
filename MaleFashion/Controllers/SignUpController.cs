using System;
using System.Web.Mvc;
using MaleFashion.BusinessLogic;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.Domain.Entities.User;
using MaleFashion.Domain.Enums;
using MaleFashion.Web.Models;

namespace MaleFashion.Web.Controllers
{
    public class SignUpController : Controller
    {
          private readonly ISession _session;
          public SignUpController()
          {
               var bl = new MyBusinessLogic();
               _session = bl.GetSessionBL();
          }
          // GET: Register
          public ActionResult Index()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Index(UserRegister register)
          {
               if (ModelState.IsValid)
               {
                    URegisterData data = new URegisterData()
                    {
                         Username = register.Username,
                         Email = register.Email,
                         Password = register.Password,
                         LoginDateTime = DateTime.Now,
                         RegisterDate = DateTime.Now,
                         Level = URole.User,
                         LoginIp = Request.UserHostAddress,
                         CartProducts = 0
                    };

                    var userRegister = _session.UserRegister(data);
                    if (userRegister.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userRegister.StatusMsg);
                         return View();
                    }
               }
               else
               {
                    return View();
               }
          }
     }
}
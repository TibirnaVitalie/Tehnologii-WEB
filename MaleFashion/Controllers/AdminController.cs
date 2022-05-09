using System.Web.Mvc;
using MaleFashion.Web.Controllers;
using MaleFashion.Web.App_Start;
using MaleFashion.Web.Extension;
using MaleFashion.Domain.Entities.User;

namespace MaleFashion.Controllers
{
    [AdminMod]
    public class AdminController : BaseController
    {
        // GET: Admin
          public ActionResult Index()
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

          public ActionResult AddProduct()
         {
               return View();
         }
    }
}
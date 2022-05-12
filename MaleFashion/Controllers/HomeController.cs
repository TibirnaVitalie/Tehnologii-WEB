using System.Web.Mvc;
using MaleFashion.Web.Extension;
using MaleFashion.Web.Models;

namespace MaleFashion.Web.Controllers
{
     public class HomeController : BaseController
     {
          // GET: Home
          public ActionResult Index()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return View(new MainData()
                    {
                         Products = GetProduct()
                    }
                    );
               }

               var user = System.Web.HttpContext.Current.GetMySessionObject();     //obtain user data from session

               MainData data = new MainData()    //merge product and user data to send in index 
               {
                    Username = user.Username,
                    Level = user.Level,
                    CartProducts = user.CartProducts,
                    Products = GetProduct()
               };
               return View(data);
          }
     }
}
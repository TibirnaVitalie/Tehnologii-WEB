using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaleFashion.Controllers
{
    public class ErrorController : Controller
    {
        // GET: LostPage
        public ActionResult Error404()
        {
            return View();
        }
    }
}
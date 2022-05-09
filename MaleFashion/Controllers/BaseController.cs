using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using MaleFashion.BusinessLogic;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.Web.Extension;
using MaleFashion.Domain.Entities.Product;

namespace MaleFashion.Web.Controllers
{
     public class BaseController : Controller
     {
          private readonly ISession _session;
          private readonly IProduct _product;
          // GET: Base
          public BaseController()
          {
               var bl = new MyBusinessLogic();
               _session = bl.GetSessionBL();
               _product = bl.GetProductBL();
          }
          public void SessionStatus()
          {
               var apiCookie = Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var uProfile = _session.GetUserByCookie(apiCookie.Value);
                    if (uProfile != null)
                    {
                         System.Web.HttpContext.Current.SetMySessionObject(uProfile);
                         System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                    }
                    else
                    {
                         System.Web.HttpContext.Current.Session.Clear();
                         if
                         (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X - KEY"))
                         {
                              var cookie =
                              ControllerContext.HttpContext.Request.Cookies["X - KEY"];
                              if (cookie != null)
                              {
                                   cookie.Expires = DateTime.Now.AddDays(-1);
                                   ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                              }
                         }
                         System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                    }
               }
               else
               {
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
               }
          }

          public List<ProductsDbTables> GetProduct()
          {
               List<ProductsDbTables> Products = _product.GetAllProducts();
               return Products;
          }

          public ProductsDbTables GetProductById(int productId)
          {
               ProductsDbTables product = _product.GetProductById(productId);
               return product;
          }
     }
}
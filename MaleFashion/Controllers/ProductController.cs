using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Web.Extension;
using MaleFashion.Web.Models;
using MaleFashion.Web.App_Start;
using MaleFashion.Domain.Entities.User;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.Domain.Entities.Product;
using AutoMapper;

namespace MaleFashion.Web.Controllers
{
     public class ProductController : BaseController
     {
        // GET: Product
        // GET: Product
          public readonly IProduct _product;
          public ProductController()
          {
               var bl = new BusinessLogic.MyBusinessLogic();
               _product = bl.GetProductBL();
          }
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

          [AdminMod]
          public ActionResult ProductAdd(HttpPostedFileBase file, ProductAddData data)
          {
               string fileName;
               if (file != null)
               {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (file != null && file.ContentLength > 0)
                    {
                         using (var md5 = MD5.Create())
                         {
                              fileName = BitConverter.ToString(md5.ComputeHash(file.InputStream)).Replace("-", "");
                              data.ImgURL = "Images/Products/" + fileName + fi.Extension;
                              string ImageFile = Path.Combine(Server.MapPath("~/Images/Products/"), fileName + fi.Extension);
                              if (!System.IO.File.Exists(ImageFile))
                              {
                                   file.SaveAs(ImageFile);
                              }
                         }
                    }
               }

               if (ModelState.IsValid)
               {
                    ProductAddData prodData = new ProductAddData()
                    {
                         ProdName = data.ProdName,
                         Category = data.Category,
                         Price = data.Price,
                         Description = data.Description,
                         ImgURL = data.ImgURL,
                         AddedDate = DateTime.Now,
                    };

                    var productAdd = _product.ProductAdd(prodData);
                    if (productAdd.Status)
                    {
                         return RedirectToAction("Index", "Shop");
                    }
                    else
                    {
                         ModelState.AddModelError("", productAdd.StatusMsg);
                         return View();
                    }
               }
               else
               {
                    return View();
               }
               
          }

          [AdminMod]
          public ActionResult ProductDeleteById(string productId)
          {
               if (ModelState.IsValid)
               {
                    var deleteProduct = _product.DeleteProductById(int.Parse(productId));

                    if (deleteProduct.Status)
                    {
                         return RedirectToAction("Index", "Shop");
                    }
                    else
                    {
                         ModelState.AddModelError("", deleteProduct.StatusMsg);
                         return RedirectToAction("ErrorFromDelete", "Error");
                    }
               }
               return RedirectToAction("ErrorFromDelete", "Error");
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult ProductUpdate(HttpPostedFileBase file, EditProductData productData)
          {
               string fileName;
               if (file != null)
               {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (file != null && file.ContentLength > 0)
                    {
                         using (var md5 = MD5.Create())
                         {
                              fileName = BitConverter.ToString(md5.ComputeHash(file.InputStream)).Replace("-", "");
                              productData.ImgURL = "Images/Products/" + fileName + fi.Extension;
                              string ImageFile = Path.Combine(Server.MapPath("~/Images/Products/"), fileName + fi.Extension);
                              if (!System.IO.File.Exists(ImageFile))
                              {
                                   file.SaveAs(ImageFile);
                              }
                         }
                    }
               }

               if (ModelState.IsValid)
               {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<EditProductData, ProductUpdateData>());
                    var mapper = config.CreateMapper();

                    ProductUpdateData data = mapper.Map<ProductUpdateData>(productData);

                    var productUpdate = _product.UpdateProduct(data);

                    if (productUpdate.Status)
                    {
                         return RedirectToAction("Index", "Shop");
                    }
                    else
                    {
                         ModelState.AddModelError("", productUpdate.StatusMsg);
                         return RedirectToAction("ErrorFromEdit", "Error");
                    }
               }
               return RedirectToAction("ErrorFromEdit", "Error");
          }

          [HttpGet]
          public ActionResult ProductEdit(int productId)
          {
               ProductsDbTables product = _product.GetProductById(productId);

               var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductsDbTables, EditProductData>());
               var mapper = config.CreateMapper();

               EditProductData productData = mapper.Map<EditProductData>(product);

               var user = System.Web.HttpContext.Current.GetMySessionObject();

               return View(productData);
          }
     }
}
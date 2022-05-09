using System;
using System.Collections.Generic;
using System.Linq;
using MaleFashion.BusinessLogic.DBModel.Seed;
using MaleFashion.Domain.Entities.Product;

namespace MaleFashion.BusinessLogic.Core
{
     internal class ProductApi : BaseApi
     {
          internal ProductAddResp ProductAddAction(ProductAddData data)
          {
               try
               {
                    ProductsDbTables product = new ProductsDbTables()
                    {
                         ProdName = data.ProdName,
                         Category = data.Category,
                         Price = data.Price,
                         Description = data.Description,
                         ImgURL = data.ImgURL,
                         AddedDate = data.AddedDate,
                    };

                    using (var db = new ProductContext())
                    {
                         db.Products.Add(product);
                         db.SaveChanges();
                    }
                    return new ProductAddResp() { Status = true};
               }
               catch (Exception ex)
               {
                    return new ProductAddResp() { Status = false, StatusMsg = ex.ToString() };
               }
          }

          internal List<ProductsDbTables> GetAllProductsAction()
          {
               List<ProductsDbTables> Products;
               
               using (var db = new ProductContext())
               {
                    Products = db.Products.ToList();
               }

               return Products;
          }
          internal ProductsDbTables GetProductByIdAction(int productId)
          {
               return GetProductById(productId);
          }

          internal ProductDeleteResp DeleteProductAction(int productId)
          {
               ProductsDbTables product;

               using (var db = new ProductContext())    //delete product data from Product table in database
               {
                    product = db.Products.FirstOrDefault(m => m.ProductId == productId);
                    db.Products.Remove(product);
                    db.SaveChanges();
               }

               return new ProductDeleteResp() { Status = true };
          }

          internal ProductUpdateResp ProductUpdateAction(ProductUpdateData data)
          {
               ProductsDbTables product;

               using (var db = new ProductContext())
               {
                    product = db.Products.FirstOrDefault(m => m.ProductId == data.ProductId);

                    product.ProdName = data.ProdName;
                    product.Category = data.Category;
                    product.Price = data.Price;
                    product.Description = data.Description;
                    product.ImgURL = data.ImgURL;

                    db.SaveChanges();
               }

               return new ProductUpdateResp() { Status = true };
          }
     }
}

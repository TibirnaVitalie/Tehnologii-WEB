using System.Linq;
using MaleFashion.Domain.Entities.Product;
using MaleFashion.BusinessLogic.DBModel.Seed;

namespace MaleFashion.BusinessLogic.Core
{
     public class BaseApi
     {
          internal ProductsDbTables GetProductById(int productId)
          {
               ProductsDbTables product;

               using (var db = new ProductContext())
               {
                    product = db.Products.FirstOrDefault(x => x.ProductId == productId);
               }

               return product;
          }
     }
}

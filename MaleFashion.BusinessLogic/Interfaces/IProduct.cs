using System.Collections.Generic;
using MaleFashion.Domain.Entities.Product;

namespace MaleFashion.BusinessLogic.Interfaces
{
     public interface IProduct
     {
          ProductAddResp ProductAdd(ProductAddData data);
          List<ProductsDbTables> GetAllProducts();
          ProductsDbTables GetProductById(int productId);
          ProductDeleteResp DeleteProductById(int productId);
          ProductUpdateResp UpdateProduct(ProductUpdateData data);
     }
}

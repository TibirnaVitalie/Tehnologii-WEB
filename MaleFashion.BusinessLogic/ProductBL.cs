using System.Collections.Generic;
using MaleFashion.BusinessLogic.Core;
using MaleFashion.BusinessLogic.Interfaces;
using MaleFashion.Domain.Entities.Product;

namespace MaleFashion.BusinessLogic
{
     internal class ProductBL : ProductApi, IProduct
     {
          public ProductAddResp ProductAdd(ProductAddData data)
          {
               return ProductAddAction(data);
          }

          public List<ProductsDbTables> GetAllProducts()
          {
               return GetAllProductsAction();
          }
          public ProductsDbTables GetProductById(int productId)
          {
               return GetProductByIdAction(productId);
          }

          public ProductDeleteResp DeleteProductById(int productId)
          {
               return DeleteProductAction(productId);
          }

          public ProductUpdateResp UpdateProduct(ProductUpdateData data)
          {
               return ProductUpdateAction(data);
          }
     }
}

using System.Data.Entity;
using MaleFashion.Domain.Entities.Product;

namespace MaleFashion.BusinessLogic.DBModel.Seed
{
     public class ProductContext : DbContext
     {
          public ProductContext() : base("name=MaleFashion")
          {
          }

          public virtual DbSet<ProductsDbTables> Products { get; set; }
     }
}

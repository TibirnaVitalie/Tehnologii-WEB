using System.Collections.Generic;
using MaleFashion.Domain.Entities.Product;
using MaleFashion.Domain.Enums;

namespace MaleFashion.Web.Models
{
     public class MainData
     {
          public string Username { get; set; }
          public URole Level { get; set; }
          public int CartProducts { get; set; }
          public List<ProductsDbTables> Products { get; set; }
     }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.Domain.Entities.Product
{
     public class ProductAddData
     {
          public string ProdName { get; set; }
          public string Category { get; set; }
          public double Price { get; set; }
          public string Description { get; set; }
          public string ImgURL { get; set; }          
          public DateTime AddedDate { get; set; }
     }
}

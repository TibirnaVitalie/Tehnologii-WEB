using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaleFashion.Web.Models
{
     public class NewProductData
     {
          public string ProdName { get; set; }
          public string Category { get; set; }
          public double Price { get; set; }
          public string Description { get; set; }          
          public string ImgURL { get; set; }
     }
}
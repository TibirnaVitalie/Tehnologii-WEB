using MaleFashion.Domain.Enums;

namespace MaleFashion.Web.Models
{
     public class EditProductData
     {
          public int ProductId { get; set; }
          public string ProdName { get; set; }
          public string Category { get; set; }
          public double Price { get; set; }
          public string Description { get; set; }
          public string ImgURL { get; set; }
          public bool[] status { get; set; }
          /*public string UserName { get; set; }
          public URole Level { get; set; }*/
     }
}
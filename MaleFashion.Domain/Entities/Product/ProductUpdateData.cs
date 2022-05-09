namespace MaleFashion.Domain.Entities.Product
{
     public class ProductUpdateData
     {
          public int ProductId { get; set; }
          public string ProdName { get; set; }
          public string Category { get; set; }
          public double Price { get; set; }
          public string Description { get; set; }
          public string ImgURL { get; set; }
          public bool[] status { get; set; }
     }
}
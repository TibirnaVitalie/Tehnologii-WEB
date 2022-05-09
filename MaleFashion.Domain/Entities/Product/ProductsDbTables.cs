using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaleFashion.Domain.Entities.Product
{
     public class ProductsDbTables
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int ProductId { get; set; }

          [Required]
          [Display(Name = "Product Name")]
          public string ProdName { get; set; }

          [Required]
          [Display(Name = "Product Category")]
          public string Category { get; set; }

          [Required]
          [Display(Name = "Price")]
          public double Price { get; set; }

          [Required]
          [Display(Name = "Description")]
          public string Description { get; set; }

          [Required]
          public string ImgURL { get; set; }

          [DataType(DataType.Date)]
          public DateTime AddedDate { get; set; }
     }
}

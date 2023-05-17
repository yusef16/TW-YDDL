using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace siteComponente.Domain.Entities.Products
{
     public class Product
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Name { get; set; }
          [Required]
          public int CategoryID { get; set; }
          [Required]
          public decimal Price { get; set; }
          [Required]
          public int Amount { get; set; }
          [Required]
          public string Thumbnail { get; set; }

     }
}

using siteComponente.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace siteComponente.Domain.Entities.Carts
{
     public class Cart
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public int CartId { get; set; }
          [Required]
          public int Quantity { get; set; }
          [Required]
          public int ProductId { get; set; }
          [NotMapped]
          public Product Product { get; set; }

     }
}
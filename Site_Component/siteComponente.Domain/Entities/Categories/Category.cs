using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using siteComponente.Domain.Entities.Products;

namespace siteComponente.Domain.Entities.Categories
{
     public class Category
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Name { get; set; }
          [Required]
          public string Thumbnail { get; set; }
     }
}

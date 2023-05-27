using System.ComponentModel.DataAnnotations;

namespace siteComponente.Web.Models
{
     public class CategoryForm
     {

          [Display(Name = "Name")]
          [Required(ErrorMessage = "You need to give category Name.")]
          public string Name { get; set; }

          [Required(ErrorMessage = "You need to provide a product Thumbnail.")]
          [DataType(DataType.ImageUrl)]
          public string Thumbnail { get; set; }
     }
}
using siteComponente.Domain.Entities.Categories;
using System.Data.Entity;

namespace siteComponente.BussinessLogic.DBModel
{
     public class CategoriesContext : DbContext
     {
          public CategoriesContext() : base("name=siteComponenteDB")
          {

          }
          public virtual DbSet<Category> Categories { get; set; }
     }
}

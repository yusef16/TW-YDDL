using System.Data.Entity;
using siteComponente.Domain.Entities.Products;

namespace siteComponente.BussinessLogic.DBModel
{
     public class ProductsContext : DbContext
     {
          public ProductsContext() : base("name=siteComponenteDB")
          {

          }
          public virtual DbSet<Product> Products { get; set; }
     }
}

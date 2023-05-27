using siteComponente.Domain.Entities.Carts;
using System.Data.Entity;

namespace siteComponente.BussinessLogic.DBModel
{
     public class CartContext : DbContext
     {
          public CartContext() : base("name=siteComponenteDB")
          {
               //Database.SetInitializer<CartContext>(null);
               EnsureDatabaseCreated();
          }

          public virtual DbSet<Cart> Carts { get; set; }
          public void EnsureDatabaseCreated()
          {
               if (!Database.Exists())
               {
                    Database.Create();
               }
          }
     }
}
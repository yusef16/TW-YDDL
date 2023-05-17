using siteComponente.Domain.Entities.User;
using System.Data.Entity;


namespace siteComponente.BussinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name=siteComponenteDB")
          {

          }
          public DbSet<User> Users { get; set; }
     }
}


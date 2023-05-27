using siteComponente.Domain.Entities;
using System.Data.Entity;

namespace siteComponente.BussinessLogic.DBModel
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("name=siteComponenteDB") { }

          public virtual DbSet<SDbModel> Sessions { get; set; }
     }
}
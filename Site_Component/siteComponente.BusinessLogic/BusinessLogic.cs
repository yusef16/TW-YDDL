using siteComponente.BussinessLogic.Interfaces;

namespace siteComponente.BussinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
          public ICategory GetCategoryBL()
          {
               return new CategoryBL();
          }
          public IProduct GetProductBL()
          {
               return new ProductBL();
          }
          public IUser GetUsertBL()
          {
               return new UserBL();
          }
          public ICart GetCartBL()
          {
               return new CartBL();
          }
     }
}
using siteComponente.Domain.Entities.Carts;
using siteComponente.Domain.Entities.Products;
using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;
using System.Collections.Generic;
namespace siteComponente.BussinessLogic.Interfaces
{
     public interface ICart
     {
          ServiceResponse ValidateAddToCart(Product item, int userId);
          ServiceResponse ValidateDeleteFromCart(Product item, int userId);
          List<Cart> GetCartItemList(User user);
     }
}

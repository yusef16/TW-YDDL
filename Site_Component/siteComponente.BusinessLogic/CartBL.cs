using siteComponente.BussinessLogic.Core;
using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Entities.Carts;
using siteComponente.Domain.Entities.Products;
using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;
using System.Collections.Generic;

namespace siteComponente.BussinessLogic
{
     public class CartBL : CartApi, ICart
     {
          public ServiceResponse ValidateAddToCart(Product item, int userId)
          {
               return ReturnAddToCart(item, userId);
          }

          public ServiceResponse ValidateDeleteFromCart(Product item, int userId)
          {
               return ReturnDeleteFromCart(item, userId);
          }

          public List<Cart> GetCartItemList(User user)
          {
               return AllCartItems(user);
          }
     }
}


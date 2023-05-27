using siteComponente.BussinessLogic.Core;
using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;

namespace siteComponente.BussinessLogic
{
     public class SessionBL : SessionApi, ISession
     {

          public ServiceResponse ValidateUserCredential(LoginData user)
          {
               return ReturnCredentialStatus(user);
          }

          public ServiceResponse ValidateUserRegister(RegisterData user)
          {
               return ReturnRegisterStatus(user);
          }

          public CookieResponse GenCookie(string username)
          {
               return CookieGeneratorAction(username);
          }

          public User GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}

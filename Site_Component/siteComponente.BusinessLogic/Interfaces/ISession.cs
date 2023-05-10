using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteComponente.BussinessLogic.Interfaces
{
     public interface ISession
     {
          ServiceResponse ValidateUserCredential(ULoginData user);
          ServiceResponse ValidateNewPassword(UChangePasswordData password);
          ServiceResponse ValidateUserRegister(URegisterData newUuser);
          CookieResponse GenCookie(string username);
          UserMinimal GetUserByCookie(string value);

     }
}


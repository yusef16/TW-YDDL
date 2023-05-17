using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static siteComponente.BussinessLogic.Core.SessionApi;

namespace siteComponente.BussinessLogic.Interfaces
{
     public interface ISession
     {
          ServiceResponse ValidateUserCredential(LoginData user);
          ServiceResponse ValidateUserRegister(RegisterData newUuser);
          CookieResponse GenCookie(string username);
          User GetUserByCookie(string value);

     }
}


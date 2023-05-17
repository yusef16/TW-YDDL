using siteComponente.BussinessLogic.Core;
using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteComponente.BussinessLogic
{
     public class UserBL : UserApi, IUser
     {
          public ServiceResponse ValidateEditUser(User data)
          {
               return ReturnEditUserStatus(data);
          }

          public ServiceResponse ValidateDeleteUser(User user)
          {
               return ReturnDeleteUserStatus(user);
          }

          public List<User> GetUserList()
          {
               return AllUsers();
          }
          public User GetUserById(int id)
          {
               return UserById(id);
          }

     }
}
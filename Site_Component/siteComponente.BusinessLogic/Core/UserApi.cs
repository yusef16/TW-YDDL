using AutoCar.Helpers;
using siteComponente.Domain.Entities.Response;
using siteComponente.Domain.Entities.User;
using siteComponente.Domain.Entities;
using siteComponente.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace siteComponente.BussinessLogic.Core
{
     public class UserApi
     {
          public ServiceResponse ReturnCredentialStatus(ULoginData user)
          {
               var hPass = LoginHelper.HashGen(user.Password);
               using (var db = new UserContext())
               {
                    var userData = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == hPass);
                    if (userData == null)
                    {
                         return new ServiceResponse { Status = false, StatusMessage = "The Username or Password is Incorrect" };
                    }
               }

               return new ServiceResponse { Status = true, StatusMessage = string.Empty };
          }

          //public CookieResponse ReturnSessionCookie(UCookieData utoken)
          //{
          //     return new CookieResponse { Data = DateTime.Now, Cookie = "name=EasyBreathDB" };
          //}

          public ServiceResponse ReturnPasswordStatus(UChangePasswordData password)
          {
               return new ServiceResponse { Status = true, StatusMessage = "Password has been changed succesfully!" };
          }

          public ServiceResponse ReturnRegisterStatus(URegisterData newUser)
          {
               var response = new ServiceResponse();
               using (var db = new UserContext())
               {
                    try
                    {
                         //     // Check if the user already exists in the database

                         var existingUser = db.Users.FirstOrDefault(u => u.Email == newUser.Email || u.Username == newUser.Username);
                         if (existingUser != null)
                         {
                              response.StatusMessage = "User with this email already exists";
                              response.Status = false;
                              return response;
                         }


                         // If the user does not exist, create a new user object and add it to the database
                         var user = new UDbModel
                         {
                              Username = newUser.Username,
                              Email = newUser.Email,
                              Password = LoginHelper.HashGen(newUser.Password),
                              RegisterDateTime = DateTime.Now,
                              LoginDateTime = DateTime.Now,
                              AccessLevel = Domain.Enum.URole.USER,
                         };
                         using (var db2 = new UserContext())
                         {
                              db2.Users.Add(user);
                              db2.SaveChanges();
                         }

                         response.StatusMessage = "User registered successfully";
                         response.Status = true;
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while registering the user";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }
          public CookieResponse CookieGeneratorAction(string username)
          {
               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(username)
               };

               using (var db = new SessionContext())
               {
                    SDbModel curent;
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(username))
                    {
                         curent = (from e in db.Sessions where e.Username == username select e).FirstOrDefault();
                    }
                    else
                    {
                         curent = (from e in db.Sessions where e.Username == username select e).FirstOrDefault();
                    }

                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(60);
                         using (var todo = new SessionContext())
                         {
                              todo.Entry(curent).State = EntityState.Modified;
                              todo.SaveChanges();
                         }
                    }
                    else
                    {
                         db.Sessions.Add(new SDbModel
                         {
                              Username = username,
                              CookieString = apiCookie.Value,
                              ExpireTime = DateTime.Now.AddMinutes(60)
                         });
                         db.SaveChanges();
                    }
               }

               return new CookieResponse
               {
                    Cookie = apiCookie,
                    Data = DateTime.Now
               };
          }
          public UserMinimal UserCookie(string cookie)
          {
               SDbModel session;
               UDbModel currentUser;

               using (var db = new SessionContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
               }

               if (session == null) return null;
               using (var db = new UserContext())
               {
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(session.Username))
                    {
                         currentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                    }
                    else
                    {
                         currentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                    }
               }

               if (currentUser == null) return null;

               var userMinimal = new UserMinimal
               {
                    Id = currentUser.Id,
                    Username = currentUser.Username,
                    Email = currentUser.Email,
                    Level = currentUser.AccessLevel
               };
               return userMinimal;
          }
     }
}
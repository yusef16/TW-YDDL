using siteComponente.BussinessLogic.Interfaces;
using siteComponente.BussinessLogic;
using siteComponente.Domain.Entities.User;
using siteComponente.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siteComponente.Web.Controllers
{
     public class AuthController : Controller
     {
          private readonly ISession _session;

          public AuthController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();

          }

          public ActionResult RegisterPage()
          {
               ViewBag.Message = "Register Page";
               return View();
          }

          [HttpPost]
          public ActionResult RegisterPage(RegisterForm data)
          {
               if (ModelState.IsValid)
               {
                    URegisterData uRegister = new URegisterData
                    {
                         Username = data.Username,
                         Password = data.Password,
                         Email = data.Email,
                    };

                    var response = _session.ValidateUserRegister(uRegister);
                    if (response.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", response.StatusMessage);
                         return View(data);
                    }
               }
               return View();
          }

          public ActionResult LoginPage()
          {
               ViewBag.Message = "Login Page";
               return View();
          }

          [HttpPost]
          public ActionResult LoginPage(LoginForm data)
          {
               if (ModelState.IsValid)
               {
                    ULoginData uLogin = new ULoginData
                    {
                         Username = data.Username,
                         Password = data.Password,
                         LoginDateTime = DateTime.Now,
                    };

                    var response = _session.ValidateUserCredential(uLogin);
                    if (response.Status)
                    {
                         var cookieResponse = _session.GenCookie(data.Username);
                         if (cookieResponse != null)
                         {
                              ControllerContext.HttpContext.Response.Cookies.Add(cookieResponse.Cookie);
                              return RedirectToAction("Index", "Home");
                         }
                         else
                         {
                              throw new Exception();
                         }
                    }
                    else
                    {
                         ViewBag.Error = "Invalid username or password.";
                         ModelState.AddModelError("Invalid username or password.", response.StatusMessage);
                         return View();
                    }
               }
               return View();
          }

          [HttpGet]
          public ActionResult Login()
          {
               return View(new LoginForm());
          }

     }
}
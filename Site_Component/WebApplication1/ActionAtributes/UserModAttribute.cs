using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Enum;
using siteComponente.Web.Extensions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace siteComponente.web.ActionAtributes
{
     public class UserModAttribute : ActionFilterAttribute
     {
          private readonly ISession _sessionBusinessLogic;

          public UserModAttribute()
          {
               var businessLogic = new BussinessLogic.BusinessLogic();
               _sessionBusinessLogic = businessLogic.GetSessionBL();
          }

          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                    if (profile != null && profile.AccessLevel == URole.USER)
                    {
                         HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                         filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                         {
                              controller = "Error",
                              action = "Error404"
                         }));
                    }
               }
               else
               {

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                         controller = "Error",
                         action = "Error404"
                    }));
               }
          }
     }
}
using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Web.Extensions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace siteComponente.Web.ActionAtributes
{
     public class AuthorizedModAttribute : ActionFilterAttribute
     {
          private readonly ISession _sessionBusinessLogic;

          public AuthorizedModAttribute()
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
                    if (profile != null)
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
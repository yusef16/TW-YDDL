using System.Web.Mvc;

namespace siteComponente.Web.Controllers
{
    public class DefaultController : BaseController
     {
          // GET: Default
          public ActionResult Index()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    System.Web.HttpContext.Current.Session.Clear();
                    //return RedirectToAction("LoginPage", "Auth");
               }
               return View();

          }

          public ActionResult blank()
        {
            return View();
        }
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult product()
        {
            return View();
        }
        public ActionResult store()
        {
            return View();
        }
          public ActionResult hard()
        {
               return View();
        }

          public ActionResult RAM()
          {
               return View();
          }

          public ActionResult CPU()
          {
               return View();
          }

        public ActionResult Video_card()
        {
            return View();
        }


        public ActionResult Categorii()
        {
            return View();
        }
        public ActionResult Placidebaza()
        {
            return View();
        }
    }
}
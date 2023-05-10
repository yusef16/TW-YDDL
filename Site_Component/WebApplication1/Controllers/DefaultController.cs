using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siteComponente.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
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
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult RegisterPage()
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
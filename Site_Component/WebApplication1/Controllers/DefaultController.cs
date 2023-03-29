using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
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
        public ActionResult login()
        {
               return View();
        }
        public ActionResult hard()
        {
               return View();
        }
     }
}
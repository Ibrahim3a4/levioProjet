using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class TajrbaController : Controller
    {
        // GET: Tajrba
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ahla(String Name, int NumFois)
        {
            ViewBag.obj1 = Name;
            ViewBag.obj2 = NumFois;
            return View();
        }
    }
}
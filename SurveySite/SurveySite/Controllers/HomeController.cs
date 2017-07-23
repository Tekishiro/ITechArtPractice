using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveySite.Controllers
{
    public class HomeController : Controller
    {
        //Homepage without any really important content
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A WebApp allowing you to convert wattbike .dat files and upload to garmin connect as .tcx files.";

            return View();
        }

        public ActionResult Export()
        {
            ViewBag.Message = "How-to export your wattbike session as .dat file";

            return View();
        }

        public ActionResult UploadToGarmin()
        {
            return View();
        }
    }
}
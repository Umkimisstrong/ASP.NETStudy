using MvcApp.DB;
using MvcApp.Models.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
                ViewBag.log = "nolog";
            else
                ViewBag.log = "log";


            return View();
        }

        public ActionResult About()
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
                ViewBag.log = "nolog";
            else
                ViewBag.log = "log";

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Tests.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        //public string Index()
        //{
        //    return "This is my <b> default </b> action...";
        //}

        /// <summary>
        /// HelloWorldController > Index()
        /// 기본 뷰(VIEW) 출력
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Index()
        {
            return View();
        }

        //// GET: HelloWolrd/Welcome/
        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}

        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is : " + numTimes); 
        //}


        /// <summary>
        /// HelloWorldController > Welcome() 
        /// name, numTimes 를 넘겨받아 출력
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numTimes"></param>
        /// <returns></returns>
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}
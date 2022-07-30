using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLayoutTest.Models;
using System.Web.UI;

namespace MVCLayoutTest.Controllers
{
    public class HomeController : Controller
    {
        // 홈 액션 - session 컨트롤
        public ActionResult Index()
        {

            string user_id = "세션없음";
            if (Session["user_id"] != null)
                 user_id = Session["user_id"].ToString();

            Response.Write(user_id);
            
                


            return View();
        }

        // 게시물 추가 액션
        public ActionResult About()
        {
            // Create Board
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // 도움말 액션
        public ActionResult Contact()
        {
            ViewBag.Message = "Help page.";

            return View();
        }

        // 로그인 액션
        public ActionResult Login()
        {
            ViewBag.Message = "Login Page";
            return View();
        }


        // 로그인 유효성 액션
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Session["user_id"] = member.user_id.ToString();
                    
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                return View("Login");
            }

            return View("Login");
        }
    }
}
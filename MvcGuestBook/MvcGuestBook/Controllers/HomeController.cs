using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGuestBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "修改此範本即可開始著手進行您的 ASP.NET MVC 應用程式。";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "您的應用程式描述頁面。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "您的連絡頁面。";

            return View();
        }

        //TODO:描述
        [NonAction] // 不要發布到web 上 or 將 public 改 private
        public ActionResult Testing()
        {
            return View();
        }

        //http://localhost:2048/Home/1
        protected override void HandleUnknownAction(String actionName)
        {
            Response.Redirect("https://www.facebook.com/");
        }
    }
}

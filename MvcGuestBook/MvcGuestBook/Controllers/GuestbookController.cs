using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcGuestBook.Models;

namespace MvcGuestBook.Controllers
{
    public class GuestbookController : Controller
    {
        private MvcGuestBookContext db = new MvcGuestBookContext();

        //
        // GET: /Guestbook/

        public ActionResult Index()
        {
            return View(db.Guestbooks.ToList());
        }

        public ActionResult Write()
        {
            return View();
        }

        //
        // POST: /Guestbook/Write

        [HttpPost]
        // 會自動將網頁表單中的名稱 對應到 Guestbook 類別中的屬性
        public ActionResult Write(Guestbook guestbook)  
        {
            if (ModelState.IsValid) // 回傳 false 表示驗證失敗
            {
                db.Guestbooks.Add(guestbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestbook); // 將網頁的資料再次船回到 View，避免資料遺失
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
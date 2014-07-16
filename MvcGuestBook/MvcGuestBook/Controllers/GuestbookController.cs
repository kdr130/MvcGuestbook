using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcGuestBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcGuestBook.Controllers
{
    public class GuestbookController : Controller
    {
        private MvcGuestBookContext db = new MvcGuestBookContext();

        //
        // GET: /Guestbook/

        public ActionResult Index()
        {
            TempData["temp"] = "tempData可不可以用呢?";
            //ViewBag.test = TempData["temp"];
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
            if (ModelState.IsValid) // 若回傳 false 表示驗證失敗
            {
                guestbook.CreatedOn = DateTime.Parse("2013/07/11");
                db.Guestbooks.Add(guestbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestbook); // 將網頁的資料再次船回到 View，避免資料遺失
        }

        public ActionResult JavaScriptTest() //會執行兩次!?
        {
            return JavaScript("alert('123')");
        }

        public class GuestbookForm
        {
            [Required]
            public int Type { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Body { get; set; }

            public string Logintime { get; set; }
        }

        public ActionResult TestForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestForm(/*[Bind(Exclude="Logintime")]GuestbookForm gbook*/
            FormCollection form)
        {
          //  if ( !ModelState.IsValid ) {
          //  return View(); 
          //  }
            //ViewData.Model = form["Confirmedpassword"];
           // return RedirectToAction("Index", "Home");

            GuestbookForm gbook = new GuestbookForm();
            //UpdateModel<GuestbookForm>(gbook);
            if (!TryUpdateModel<GuestbookForm>(gbook))
            {
                // 模型連結發生失敗
                return View();
            }
            
            return Redirect("/");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
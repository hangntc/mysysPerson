using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Areas.Admin.Controllers
{
    public class SysTitleController : Controller
    {
        // GET: Admin/SysTitle

        // GET: Administrator/BaiVietHeThongs
       private ModelClient db = new ModelClient();

        

        public ActionResult Index()
        {
            return View(db.BaiVietHeThongs.Where(s => s.cCode != "Banner").ToList());
        }

        // GET: Administrator/BaiVietHeThongs/Details/5
        [HttpGet]
        public ActionResult BaiVietHeThong()
        {
            BaiVietHeThong baiVietHeThong = null;
            var lienhe = db.BaiVietHeThongs.Where(s => s.cCode == "ContactUs" && s.cLangID == "vi-VN").ToList().FirstOrDefault();
            ViewBag.lienhe = lienhe;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("BaiVietHeThongAdmin");
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<BaiVietHeThong>();
                    readTask.Wait();
                    baiVietHeThong = readTask.Result;
                }
            }
            return View(baiVietHeThong);
        }

        // GET: Administrator/BaiVietHeThongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/BaiVietHeThongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,cCode,cValue,cLangID,cUpdateTime")] BaiVietHeThong baiVietHeThong)
        {
            if (ModelState.IsValid)
            {
                db.BaiVietHeThongs.Add(baiVietHeThong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baiVietHeThong);
        }

        // GET: Administrator/BaiVietHeThongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietHeThong baiVietHeThong = db.BaiVietHeThongs.Find(id);
            if (baiVietHeThong == null)
            {
                return HttpNotFound();
            }
            return View(baiVietHeThong);
        }

        // POST: Administrator/BaiVietHeThongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,cCode,cValue,cLangID,cUpdateTime")] BaiVietHeThong baiVietHeThong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiVietHeThong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiVietHeThong);
        }

        // GET: Administrator/BaiVietHeThongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietHeThong baiVietHeThong = db.BaiVietHeThongs.Find(id);
            if (baiVietHeThong == null)
            {
                return HttpNotFound();
            }
            return View(baiVietHeThong);
        }

        // POST: Administrator/BaiVietHeThongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiVietHeThong baiVietHeThong = db.BaiVietHeThongs.Find(id);
            db.BaiVietHeThongs.Remove(baiVietHeThong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HienthiBanner()
        {
            var ht = db.BaiVietHeThongs.Where(s => s.cCode == "Banner").ToList();
            return View(ht);
        }
        public ActionResult SuaBanner(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietHeThong baiVietHeThong = db.BaiVietHeThongs.Find(id);
            if (baiVietHeThong == null)
            {
                return HttpNotFound();
            }
            return View(baiVietHeThong);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaBanner([Bind(Include = "ID,cCode,cValue,cLangID,cUpdateTime")] BaiVietHeThong baiVietHeThong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiVietHeThong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiVietHeThong);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Close()
        {
            return RedirectToAction("Index", "Default");
        }
    }
}
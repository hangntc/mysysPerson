using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Areas.Admin.Controllers
{
    public class UserAdController : Controller
    {
        private ModelClient db = new ModelClient();

        // GET: Admin/NguoiDungAdmin
        public ActionResult Index()
        {
            IEnumerable<NguoiDung> nguoiDungs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("NguoiDungAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<NguoiDung>>();
                    readTask.Wait();
                    nguoiDungs = readTask.Result;
                }
                else
                {
                    nguoiDungs = Enumerable.Empty<NguoiDung>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(nguoiDungs);
        }

       

        // GET: Admin/NguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        [HttpPost]
        public ActionResult Create(NguoiDung a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("NguoiDungAdmin", a);
                postTask.Wait();
                var kq = postTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(a);
            // return RedirectToAction("DSNhanVien2");
        }

        // GET: Admin/NguoiDungs/Edit/5
        public ActionResult Edit(int id)
        {
            NguoiDung nguoiDung = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var edit = client.GetAsync("NguoiDungAdmin/?id=" + id.ToString());
                edit.Wait();
                var kq = edit.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<NguoiDung>();
                    readTask.Wait();
                    nguoiDung = readTask.Result;
                }
            }
            return View(nguoiDung);
        }
        [HttpPost]
        public ActionResult Edit(NguoiDung a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var putTask = client.PutAsJsonAsync("NguoiDungAdmin/" + a.Id, a);
                putTask.Wait();

                var kq = putTask.Result;

                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(a);
            }

        }

        // GET: Admin/NguoiDungs/Delete/5
        public ActionResult Delete(int id)
        {
            NguoiDung nguoiDung = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("NguoiDungAdmin/?id=" + id.ToString());
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<NguoiDung>();
                    readTask.Wait();
                    nguoiDung = readTask.Result;
                }
            }
            return View(nguoiDung);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Ddelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("NguoiDungAdmin/?id=" + id.ToString());
                delete.Wait();
                var kq = delete.Result;
                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

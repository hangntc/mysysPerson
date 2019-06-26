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
    public class ProducerController : Controller
    {
        ModelClient db = new ModelClient();
        public ActionResult Index()
        {
            IEnumerable<HangSX> hangSXes = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("HangSXAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<HangSX>>();
                    readTask.Wait();
                    hangSXes = readTask.Result;
                }
                else
                {
                    hangSXes = Enumerable.Empty<HangSX>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(hangSXes);
        }
        // GET: Admin/NguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        [HttpPost]
        public ActionResult Create(HangSX a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("HangSXAdmin", a);
                postTask.Wait();
                var kq = postTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(a);
        }

        // GET: Admin/NguoiDungs/Edit/5
        public ActionResult Edit(int id)
        {
            HangSX hangSX = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var edit = client.GetAsync("HangSXAdmin/?id=" + id.ToString());
                edit.Wait();
                var kq = edit.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<HangSX>();
                    readTask.Wait();
                    hangSX = readTask.Result;
                }
            }
            return View(hangSX);
        }
        [HttpPost]
        public ActionResult Edit(HangSX a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var putTask = client.PutAsJsonAsync("HangSXAdmin/" + a.IdHang, a);
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
            HangSX hangSX = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("HangSXAdmin/?id=" + id.ToString());
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<HangSX>();
                    readTask.Wait();
                    hangSX = readTask.Result;
                }
            }
            return View(hangSX);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Ddelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("HangSXAdmin/?id=" + id.ToString());
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
        public ActionResult Close()
        {
            return RedirectToAction("Index", "Default");
        }
    }
}
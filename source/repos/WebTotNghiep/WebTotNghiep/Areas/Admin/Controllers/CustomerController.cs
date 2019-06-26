using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private ModelClient db = new ModelClient();

        // GET: Admin/KhachHangAdmin
        public ActionResult Index()
        {
            IEnumerable<KhachHang> khachHangs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("KhachHangAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<KhachHang>>();
                    readTask.Wait();
                    khachHangs = readTask.Result;
                }
                else
                {
                    khachHangs = Enumerable.Empty<KhachHang>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(khachHangs);
        } 
        // GET: Admin/KhachHangAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHangAdmin/Create
        [HttpPost]
        public ActionResult Create(KhachHang a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("KhachHangAdmin", a);
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

        // GET: Admin/KhachHangAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            KhachHang khachHang = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var edit = client.GetAsync("KhachHangAdmin/?id=" + id.ToString());
                edit.Wait();
                var kq = edit.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<KhachHang>();
                    readTask.Wait();
                    khachHang = readTask.Result;
                }
            }
            return View(khachHang);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var putTask = client.PutAsJsonAsync("KhachHangAdmin/" + a.IdKhachhang, a);
                putTask.Wait();

                var kq = putTask.Result;

                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(a);
            }

        }
        // GET: Admin/KhachHangAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            KhachHang khachHang = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("KhachHangAdmin/?id=" + id.ToString());
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<KhachHang>();
                    readTask.Wait();
                    khachHang = readTask.Result;
                }
            }
            return View(khachHang);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Ddelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("KhachHangAdmin/?id=" + id.ToString());
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

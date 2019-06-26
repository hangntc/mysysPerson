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
    public class TypeProductController : Controller
    {
        ModelClient db = new ModelClient();
        public ActionResult Index()
        {
            IEnumerable<LoaiSanPham> loaiSanPhams = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("LoaiSanPhamAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<LoaiSanPham>>();
                    readTask.Wait();
                    loaiSanPhams = readTask.Result;
                }
                else
                {
                    loaiSanPhams = Enumerable.Empty<LoaiSanPham>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(loaiSanPhams);
        } 
        // GET: Admin/NguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("LoaiSanPhamAdmin", a);
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
            LoaiSanPham loaiSanPhams = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var edit = client.GetAsync("LoaiSanPhamAdmin/?id=" + id.ToString());
                edit.Wait();
                var kq = edit.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<LoaiSanPham>();
                    readTask.Wait();
                    loaiSanPhams = readTask.Result;
                }
            }
            return View(loaiSanPhams);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSanPham a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var putTask = client.PutAsJsonAsync("LoaiSanPhamAdmin/" + a.IdLoai, a);
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
            LoaiSanPham loaiSanPhams = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("LoaiSanPhamAdmin/?id=" + id.ToString());
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<LoaiSanPham>();
                    readTask.Wait();
                    loaiSanPhams = readTask.Result;
                }
            }
            return View(loaiSanPhams);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Ddelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("LoaiSanPhamAdmin/?id=" + id.ToString());
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
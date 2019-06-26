using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using WebTotNghiep.Models;


namespace WebTotNghiep.Areas.Admin.Controllers
{
    public class ProductAdController : Controller
    {
        ModelClient db = new ModelClient();
        // GET: Admin/SanphamAdmin
        public ActionResult Index()
        {
            IEnumerable<Sanpham> sanphams = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("SanphamAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<Sanpham>>();
                    readTask.Wait();
                    sanphams = readTask.Result;
                }
                else
                {
                    sanphams = Enumerable.Empty<Sanpham>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(sanphams);
        }


        // GET: Admin/SanphamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SanphamAdmin/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Sanpham a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("SanphamAdmin", a);
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

        // GET: Admin/SanphamAdmin/Edit/5
        // GET: Admin/NguoiDungs/Edit/5
        public ActionResult Edit(string id)
        {
            Sanpham sanphams = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var edit = client.GetAsync("SanphamAdmin/?id=" + id.ToString());
                edit.Wait();
                var kq = edit.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<Sanpham>();
                    readTask.Wait();
                    sanphams = readTask.Result;
                }
            }
            return View(sanphams);
        }
        [HttpPost]
        public ActionResult Edit(Sanpham a)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var putTask = client.PutAsJsonAsync("SanphamAdmin/" + a.id, a);
                putTask.Wait();

                var kq = putTask.Result;

                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(a);
            }

        }

        // GET: Admin/SanphamAdmin/Delete/5
        public ActionResult Delete(int[] id)
        {
            Sanpham sanphams = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("SanphamAdmin/?id=" + id);
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<Sanpham>();
                    readTask.Wait();
                    sanphams = readTask.Result;
                }

            }
            return View(sanphams);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Ddelete(int[] id)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("SanphamAdmin/?id=" + id);
                delete.Wait();
                var kq = delete.Result;
                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("UploadImage", file);
                postTask.Wait();
                var kq = postTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(file);
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


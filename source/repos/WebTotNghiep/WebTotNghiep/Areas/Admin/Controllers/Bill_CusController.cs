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
    public class Bill_CusController : Controller
    {
       private ModelClient db = new ModelClient();
        public ActionResult Index()
        {
            IEnumerable<Donhang_KhachHang> donhang_KhachHangs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("Bill_CusAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<Donhang_KhachHang>>();
                    readTask.Wait();
                    donhang_KhachHangs = readTask.Result;
                }
                else
                {
                    donhang_KhachHangs = Enumerable.Empty<Donhang_KhachHang>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(donhang_KhachHangs);
        }

        // GET: Admin/Bill_Cus/Delete/5
        public ActionResult Delete(string id)
        {
            Donhang_KhachHang donhang_KhachHang = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("Bill_CusAdmin/?id=" + id.ToString());
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<Donhang_KhachHang>();
                    readTask.Wait();
                    donhang_KhachHang = readTask.Result;
                }
            }
            return View(donhang_KhachHang);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Ddelete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("Bill_CusAdmin/?id=" + id.ToString());
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

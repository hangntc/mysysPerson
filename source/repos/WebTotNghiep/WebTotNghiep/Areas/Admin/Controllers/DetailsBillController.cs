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
    public class DetailsBillController : Controller
    {
        ModelClient db = new ModelClient();
        public ActionResult Index()
        {
            IEnumerable<Chitietdonhang> chitietdonhangs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("ChitietdonhangAdmin");
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<IList<Chitietdonhang>>();
                    readTask.Wait();
                    chitietdonhangs = readTask.Result;
                }
                else
                {
                    chitietdonhangs = Enumerable.Empty<Chitietdonhang>();
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return View(chitietdonhangs);
        }
        // GET: Administrator/Donhang_KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            Chitietdonhang chitietdonhangs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("ChitietdonhangAdmin/?id=" + id.ToString());
                dts.Wait();
                var kq = dts.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<Chitietdonhang>();
                    readTask.Wait();
                    chitietdonhangs = readTask.Result;
                }
            }
            return View(chitietdonhangs);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Ddelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var delete = client.DeleteAsync("ChitietdonhangAdmin/?id=" + id.ToString());
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
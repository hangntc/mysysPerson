using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Controllers
{

    public class ProductController : Controller
    {
        // GET: Product
        ModelClient db = new ModelClient();

        public ActionResult ProductHot()
        {
            //var ds = db.Sanphams.OrderByDescending(s => s.id).ToList().Take(10);
            //return PartialView(ds);

            IEnumerable<Sanpham> sanphams = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");

                var responseTask = client.GetAsync("Sanphams");
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
        [HttpGet]
        public ActionResult DetailProduct(int id)
        {
            Sanpham sanphams = null;
            var chitiet = db.Sanphams.Where(s => s.id == id).ToList().FirstOrDefault();
            var splq = db.Sanphams.Where(s => s.IdLoai == chitiet.IdLoai && s.id != chitiet.id).ToList();
            ViewBag.sqlq = splq;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var dts = client.GetAsync("Sanphams/?id=" + id.ToString());
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
        public ActionResult Find( string txtTimKiem)
        {
            //Sanpham sanphams = null;
            List<Sanpham> kqtk = db.Sanphams.Where(s => s.Ten.Contains(txtTimKiem)).ToList();
            ViewBag.kq = kqtk;
            if (kqtk.Count != 0)
            {
                return PartialView(kqtk);
            }
            else
            {
                ViewBag.thongbao = "Không tìm thấy sản phẩm cần tìm";
                return View();
            } 
        }
    }
}
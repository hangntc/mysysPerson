using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTotNghiep.Models;

namespace WebTotNghiep.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        ModelClient db = new ModelClient();
        public ActionResult ListKhachHang()
        {
            IEnumerable<KhachHang> khachHangs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");

                var responseTask = client.GetAsync("KhachHangs");
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
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(KhachHang account, string returnUrl)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("KhachHangs?txtTen=" + account.Tentruynhap + "&txtMK=" + account.Matkhau);
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<KhachHang>();
                    readTask.Wait();
                    account = readTask.Result;
                }
                else
                {
                    ViewBag.Error = "tài khoản không đúng";
                    return View("Login");
                }
            }
            var kh = db.KhachHangs.Where(s => s.Tentruynhap == account.Tentruynhap && s.Matkhau == account.Matkhau).FirstOrDefault();
            {
                if (kh != null)
                {
                    Session["KH"] = kh;
                    Session["Tentruycap"] = kh.Tentruynhap.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["ms"] = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KhachHang a)
        {
            var kh = db.KhachHangs.Where(s => s.Tentruynhap == a.Tentruynhap).ToList().FirstOrDefault();
            if (kh != null)
            {
                ViewBag.ms = "Tên đăng nhập đã tồn tại";
                return View();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var postTask = client.PostAsJsonAsync("KhachHangs", a);
                postTask.Wait();
                var kq = postTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(a);  
        }
        public ActionResult Logout(string returnUrl)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
        
    }
}
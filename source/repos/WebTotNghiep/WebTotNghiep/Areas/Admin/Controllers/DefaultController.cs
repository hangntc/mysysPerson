using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        private ModelClient db = new ModelClient();
        // GET: Admin/Default
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Session["Username"].ToString()))
            {
                return RedirectToAction("LoginAd");
            }
            else
            {
                return View();
            }
        }
        public PartialViewResult Menu()
        {

            return PartialView();
        }
        public ActionResult LoginAd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult LoginAd(NguoiDung account, string returnUrl)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54779/api/");
                var responseTask = client.GetAsync("NguoiDungAdmin?txtTen=" + account.Username + "&txtMK=" + account.Password);
                responseTask.Wait();
                var kq = responseTask.Result;
                if (kq.IsSuccessStatusCode)
                {
                    var readTask = kq.Content.ReadAsAsync<NguoiDung>();
                    readTask.Wait();

                    account = readTask.Result;
                }
                else
                {
                    ViewBag.Error = "tài khoản không đúng";
                    return View("LoginAd");
                }
            }
            var kh = db.NguoiDungs.Where(s => s.Username == account.Username && s.Password == account.Password).FirstOrDefault();
            {
                if (kh != null)
                {
                    Session["KH"] = kh;
                    Session["Username"] = kh.Username.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["ms"] = "Đăng nhập không thành công";
                    return RedirectToAction("LoginAd");
                }
            }
        }
        public ActionResult Logout()
        {
            Session["Username"] = "";
            Session["Password"] = "";
            return RedirectToAction("LoginAd");
        }
    }
}
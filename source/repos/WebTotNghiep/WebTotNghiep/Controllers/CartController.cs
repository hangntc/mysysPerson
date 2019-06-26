using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        const string cartname = "giohang";
        ModelClient db = new ModelClient();
        public ActionResult Index()
        {
            var giohang = (List<GioHang>)Session[cartname];
            return View(giohang);
        }
        public ActionResult ThemGioHang(int id)
        {
            var giohang = (List<GioHang>)Session[cartname];
            var sanpham = db.Sanphams.Find(id);
            if (giohang != null)
            {
                if (giohang.Exists(x => x.Sanpham.id == id))
                {
                    var sp = giohang.Where(s => s.Sanpham.id == id).FirstOrDefault();
                    sp.SoLuong += sp.SoLuong;
                }
                else
                {
                    GioHang gh = new GioHang(sanpham, 1);
                    giohang.Add(gh);
                }
                Session[cartname] = giohang;
            }
            else
            {
                GioHang gh = new GioHang(sanpham, 1);
                var list = new List<GioHang>();
                list.Add(gh);
                Session[cartname] = list;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult TinhLai(int[] id, int[] soluong)
        {
            var k = 0;
            var giohang = (List<GioHang>)Session[cartname];
            foreach (int i in id)
            {
                if (giohang.Exists(s => s.Sanpham.id == i))
                {
                    var sp = giohang.Where(s => s.Sanpham.id == i).FirstOrDefault();
                    sp.SoLuong = soluong[k];
                }
                k++;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Pay()
        {
            if (Session["KH"] != null)
            {
                return RedirectToAction("DiaChi");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Login(string txtTen, string txtMatKhau)
        {
            var kh = db.KhachHangs.Where(s => s.Tentruynhap == txtTen && s.Matkhau == txtMatKhau).ToList().FirstOrDefault();
            if (kh != null)
            {
                Session["KH"] = kh;

                return RedirectToAction("Address");
            }
            else
            {
                Session["ms"] = "Đăng nhập không thành công";
                return RedirectToAction("Pay");
            }

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string txtHoTen, string txtDienThoai, string txtDiaChi, string txtTenDangNhap, string txtMatKhau)
        {
            var khachhang = db.KhachHangs.Where(s => s.Tenkhachhang == txtHoTen).ToList().FirstOrDefault();
            if (khachhang != null)
            {
                ViewBag.ms = "Tên đăng nhập đã tồn tại";
                return View();
            }
            else
            {
                KhachHang KH = new KhachHang();
                KH.Tentruynhap = txtTenDangNhap;
                KH.Tenkhachhang = txtHoTen;
                KH.Diachi = txtDiaChi;
                KH.Dienthoai = txtDienThoai;
                KH.Matkhau = txtMatKhau;
                db.KhachHangs.Add(KH);
                db.SaveChanges();
                Session["KH"] = KH;
                return RedirectToAction("DiaChi");
            }

        }
        public ActionResult Address()
        {
            KhachHang khachhang = new KhachHang();
            khachhang = (KhachHang)Session["KH"];
            return View(khachhang);
        }
        [HttpPost]
        public ActionResult AddAddress(string Tenkhachhang, string Dienthoai, string Diachi, string txtYeuCau, string txtNgayGiaoHang)
        {
            Donhang_KhachHang dh = new Donhang_KhachHang();
            KhachHang khachhang = new KhachHang();
            khachhang = (KhachHang)Session["KH"];
            dh.Idkhachhang = khachhang.IdKhachhang;
            dh.Tennguoinhan = Tenkhachhang;
            dh.Diachinguoinhan = Diachi;
            dh.DTnguoinhan = Dienthoai;
            dh.Yeucau = txtYeuCau;
            dh.Ngaygiao = Convert.ToDateTime(txtNgayGiaoHang);
            dh.Ngaydat = DateTime.Now;
            //db.Donhang_KhachHang.Add(dh);
            //db.SaveChanges();
            Session["dathang"] = dh;
            return RedirectToAction("Order");
        }
        public ActionResult Order()
        {
            ViewBag.kh = (KhachHang)Session["KH"];
            ViewBag.gh = (List<GioHang>)Session[cartname];
            ViewBag.dh = (Donhang_KhachHang)Session["dathang"];
            return View();
        }
        [HttpPost]

        public ActionResult Order(string rdphuongthuctt)
        {
            KhachHang kh = (KhachHang)Session["KH"];
            List<GioHang> gh = (List<GioHang>)Session[cartname];
            Donhang_KhachHang dh = (Donhang_KhachHang)Session["dathang"];
            dh.Kieuthanhtoan = rdphuongthuctt;
            db.Donhang_KhachHang.Add(dh);
            foreach (var item in gh)
            {
                Chitietdonhang chitiet = new Chitietdonhang();
                chitiet.IdDonHang = dh.IdDonHang;
                chitiet.IdSanPham = item.Sanpham.id;
                chitiet.Soluong = item.SoLuong;
                chitiet.Dongia = item.Sanpham.GiaMoi;
                db.Chitietdonhangs.Add(chitiet);
                db.SaveChanges();

            }

            return RedirectToAction("OrderSuccess");
        }
        public ActionResult OrderSuccess()
        {

            return View();
        }
    }
}
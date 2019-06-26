using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTotNghiep.Models
{
    public class GioHang
    {
        // GET: GioHang
        public Sanpham Sanpham { get; set; }
        public int SoLuong { get; set; }
        public GioHang (Sanpham sp, int soluong)
        {
            this.Sanpham = sp;
            this.SoLuong = soluong;
        }
    }
}
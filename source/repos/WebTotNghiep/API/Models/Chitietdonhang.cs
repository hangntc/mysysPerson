namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietdonhang")]
    public partial class Chitietdonhang
    {
        public int Id { get; set; }

        public int? IdDonHang { get; set; }

        public int? IdSanPham { get; set; }

        public int? Soluong { get; set; }

        public double? Dongia { get; set; }

        public virtual Donhang_KhachHang Donhang_KhachHang { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}

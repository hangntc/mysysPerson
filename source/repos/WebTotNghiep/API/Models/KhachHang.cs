namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int IdKhachhang { get; set; }

        [Required]
        [StringLength(100)]
        public string Tentruynhap { get; set; }

        [Required]
        [StringLength(200)]
        public string Matkhau { get; set; }

        [StringLength(200)]
        public string Tenkhachhang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(10)]
        public string Gioitinh { get; set; }

        [StringLength(200)]
        public string Diachi { get; set; }

        [StringLength(12)]
        public string Dienthoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(300)]
        public string Cauhoi { get; set; }

        [StringLength(30)]
        public string Traloi { get; set; }

        public DateTime? Ngaytao { get; set; }
    }
}

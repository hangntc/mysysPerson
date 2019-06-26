namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSanPham { get; set; }

        public int? IdLoai { get; set; }

        [Required]
        [StringLength(256)]
        public string Ten { get; set; }

        [StringLength(30)]
        public string Model { get; set; }

        [StringLength(300)]
        public string MotaNgan { get; set; }

        [Column(TypeName = "ntext")]
        public string MotaChiTiet { get; set; }

        [Column(TypeName = "ntext")]
        public string TSKyThuat { get; set; }

        [StringLength(300)]
        public string Tukhoa { get; set; }

        public int? IdHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhatCuoi { get; set; }

        public double? GiaCu { get; set; }

        public double? GiaMoi { get; set; }

        public short? Uutien { get; set; }

        [StringLength(300)]
        public string HinhAnh { get; set; }

        [StringLength(300)]
        public string HinhAnh1 { get; set; }

        public bool? TieuBieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }

        public virtual HangSX HangSX { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}

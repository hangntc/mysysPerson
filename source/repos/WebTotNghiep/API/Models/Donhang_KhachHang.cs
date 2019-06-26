namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donhang_KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donhang_KhachHang()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        [Key]
        public int IdDonHang { get; set; }

        public int? Idkhachhang { get; set; }

        public DateTime? Ngaydat { get; set; }

        public DateTime? Ngaygiao { get; set; }

        [Column(TypeName = "ntext")]
        public string Yeucau { get; set; }

        [StringLength(100)]
        public string Kieuthanhtoan { get; set; }

        public int? Trangthai { get; set; }

        public int? Duyet { get; set; }

        [StringLength(50)]
        public string Tennguoinhan { get; set; }

        [StringLength(50)]
        public string DTnguoinhan { get; set; }

        [StringLength(50)]
        public string EmailnguoiNhan { get; set; }

        [StringLength(200)]
        public string Diachinguoinhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}

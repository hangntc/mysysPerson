namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSanPham()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        public int IdLoai { get; set; }

        [StringLength(256)]
        public string Ten { get; set; }

        [StringLength(300)]
        public string Tieude { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public short? Uutien { get; set; }

        [StringLength(256)]
        public string Hinhanh { get; set; }

        [StringLength(300)]
        public string Tukhoa { get; set; }

        public int? Vitri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}

namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public int? Thutu { get; set; }

        [StringLength(50)]
        public string Trang { get; set; }

        [StringLength(50)]
        public string ThuMuc { get; set; }

        public bool? Active { get; set; }
    }
}

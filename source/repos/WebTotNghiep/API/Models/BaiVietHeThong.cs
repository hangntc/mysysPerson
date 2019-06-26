namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiVietHeThong")]
    public partial class BaiVietHeThong
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string cCode { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string cValue { get; set; }

        [Required]
        [StringLength(10)]
        public string cLangID { get; set; }

        public DateTime cUpdateTime { get; set; }
    }
}

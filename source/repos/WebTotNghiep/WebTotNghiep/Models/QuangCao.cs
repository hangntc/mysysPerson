namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string AdsName { get; set; }

        [Required]
        [StringLength(150)]
        public string AdsUrl { get; set; }

        [Required]
        [StringLength(150)]
        public string AdsImage { get; set; }

        public int AdsIndex { get; set; }

        public int AdsViewed { get; set; }
    }
}

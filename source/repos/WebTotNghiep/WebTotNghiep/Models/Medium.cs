namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Ten { get; set; }

        [StringLength(512)]
        public string LienKet { get; set; }

        public int? Vitri { get; set; }

        public int? Loai { get; set; }
    }
}

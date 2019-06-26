namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbvisistor")]
    public partial class tbvisistor
    {
        public int Id { get; set; }

        public int? iuseronline { get; set; }

        public long? ivisistor { get; set; }

        public int? iuseronlinedate { get; set; }

        public DateTime? dateonline { get; set; }
    }
}

namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupSupport")]
    public partial class GroupSupport
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public int? Ord { get; set; }

        public int? Active { get; set; }

        [StringLength(5)]
        public string Lang { get; set; }
    }
}

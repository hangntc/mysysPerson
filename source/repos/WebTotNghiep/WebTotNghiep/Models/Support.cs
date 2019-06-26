namespace WebTotNghiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Support")]
    public partial class Support
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Tel { get; set; }

        public int? Type { get; set; }

        [StringLength(128)]
        public string Nick { get; set; }

        public int? Ord { get; set; }

        public int? Active { get; set; }

        public int? GroupSupportId { get; set; }

        public int? Location { get; set; }
    }
}

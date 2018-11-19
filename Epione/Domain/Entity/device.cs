namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.device")]
    public partial class device
    {
        public int id { get; set; }

        [StringLength(255)]
        public string browser { get; set; }

        [Column(TypeName = "bit")]
        public bool? connected { get; set; }

        [StringLength(255)]
        public string ip { get; set; }

        public DateTime? lastConnection { get; set; }

        [StringLength(255)]
        public string os { get; set; }

        public int? owner_id { get; set; }
    }
}

namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.demandedoctolib")]
    public partial class demandedoctolib
    {
        public int id { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string specialite { get; set; }

        [StringLength(255)]
        public string ville { get; set; }

        [StringLength(255)]
        public string email { get; set; }
    }
}

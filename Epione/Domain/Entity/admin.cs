namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.admin")]
    public partial class admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public DateTime? birthDay { get; set; }

        [Column(TypeName = "bit")]
        public bool? connected { get; set; }

        public DateTime? dateCreation { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        [Column(TypeName = "bit")]
        public bool? isEnable { get; set; }

        public DateTime? lastConnect { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int phoneNumber { get; set; }

        [StringLength(255)]
        public string token { get; set; }
    }
}

namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.rendezvous")]
    public partial class rendezvou
    {
        public int id { get; set; }

        [Column(TypeName = "tinyblob")]
        public byte[] Medecin { get; set; }

        public DateTime? date { get; set; }

        [Column(TypeName = "bit")]
        public bool etat { get; set; }

        public int heureDebut { get; set; }

        public int heureFin { get; set; }

        [Column(TypeName = "tinyblob")]
        public byte[] motif { get; set; }

        public int ordreAttente { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        public int? patient_id { get; set; }

        public int? Medecin_id { get; set; }

        public int? motif_id { get; set; }

        public int? parcours_id { get; set; }

        public virtual doctor doctor { get; set; }

        public virtual motif motif1 { get; set; }

        public virtual parcour parcour { get; set; }

        public virtual patient patient { get; set; }
    }
}

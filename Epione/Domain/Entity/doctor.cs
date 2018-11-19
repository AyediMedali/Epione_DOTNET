namespace Domain.Entity
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.doctor")]
    public partial class doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doctor()
        {
            calendriers = new HashSet<calendrier>();
            parcours = new HashSet<parcour>();
            rendezvous = new HashSet<rendezvou>();
            exercices = new HashSet<exercice>();
            expertisedoctors = new HashSet<expertisedoctor>();
            formations = new HashSet<formation>();
            langues = new HashSet<langue>();
            motifs = new HashSet<motif>();
            tarifs = new HashSet<tarif>();
        }

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

        [StringLength(255)]
        public string codePostal { get; set; }

        [StringLength(255)]
        public string numAppart { get; set; }

        [StringLength(255)]
        public string rue { get; set; }

        [StringLength(255)]
        public string ville { get; set; }

        public DateTime? dateOuverture { get; set; }

        public DateTime? dateSansRDV { get; set; }

        [StringLength(255)]
        public string presentation { get; set; }

        [StringLength(255)]
        public string specialite { get; set; }

        [Column(TypeName = "bit")]
        public bool? doctolib { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calendrier> calendriers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<parcour> parcours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvou> rendezvous { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<exercice> exercices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<expertisedoctor> expertisedoctors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formation> formations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<langue> langues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<motif> motifs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarif> tarifs { get; set; }
    }
}

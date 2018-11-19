namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.parcours")]
    public partial class parcour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public parcour()
        {
            treatments = new HashSet<treatment>();
            rendezvous = new HashSet<rendezvou>();
            patients = new HashSet<patient>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string doctorNote { get; set; }

        [StringLength(255)]
        public string justification { get; set; }

        [Column(TypeName = "bit")]
        public bool state { get; set; }

        public int? doctor_id { get; set; }

        public virtual doctor doctor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<treatment> treatments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvou> rendezvous { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patient> patients { get; set; }
    }
}

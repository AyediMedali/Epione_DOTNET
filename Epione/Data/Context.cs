namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entity;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<calendrier> calendriers { get; set; }
        public virtual DbSet<demandedoctolib> demandedoctolibs { get; set; }
        public virtual DbSet<device> devices { get; set; }
        public virtual DbSet<doctor> doctors { get; set; }
        public virtual DbSet<exercice> exercices { get; set; }
        public virtual DbSet<expertisedoctor> expertisedoctors { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<horaire> horaires { get; set; }
        public virtual DbSet<journee> journees { get; set; }
        public virtual DbSet<langue> langues { get; set; }
        public virtual DbSet<motif> motifs { get; set; }
        public virtual DbSet<parcour> parcours { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<rendezvou> rendezvous { get; set; }
        public virtual DbSet<tarif> tarifs { get; set; }
        public virtual DbSet<treatment> treatments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<calendrier>()
                .HasMany(e => e.journees)
                .WithMany(e => e.calendriers)
                .Map(m => m.ToTable("calendrier_journee").MapLeftKey("Calendrier_id").MapRightKey("listJournees_id"));

            modelBuilder.Entity<demandedoctolib>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<demandedoctolib>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<demandedoctolib>()
                .Property(e => e.specialite)
                .IsUnicode(false);

            modelBuilder.Entity<demandedoctolib>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<demandedoctolib>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<device>()
                .Property(e => e.browser)
                .IsUnicode(false);

            modelBuilder.Entity<device>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<device>()
                .Property(e => e.os)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.token)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.numAppart)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.presentation)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.specialite)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.calendriers)
                .WithOptional(e => e.doctor)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.parcours)
                .WithOptional(e => e.doctor)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.rendezvous)
                .WithOptional(e => e.doctor)
                .HasForeignKey(e => e.Medecin_id);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.exercices)
                .WithMany(e => e.doctors)
                .Map(m => m.ToTable("doctor_exercices").MapRightKey("exercices_id"));

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.expertisedoctors)
                .WithMany(e => e.doctors)
                .Map(m => m.ToTable("doctor_expertisedoctor").MapRightKey("expertises_id"));

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.formations)
                .WithMany(e => e.doctors)
                .Map(m => m.ToTable("doctor_formations").MapRightKey("formations_id"));

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.langues)
                .WithMany(e => e.doctors)
                .Map(m => m.ToTable("doctor_langues").MapRightKey("langues_id"));

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.motifs)
                .WithMany(e => e.doctors)
                .Map(m => m.ToTable("doctor_motif").MapRightKey("listMotifs_id"));

            modelBuilder.Entity<exercice>()
                .Property(e => e.lieu)
                .IsUnicode(false);

            modelBuilder.Entity<expertisedoctor>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.diplome)
                .IsUnicode(false);

            modelBuilder.Entity<journee>();
                //.HasMany(e => e.horaires)
                //.WithOptional(e => e.journee)
                //.HasForeignKey(e => e.journee_id);

            modelBuilder.Entity<langue>()
                .Property(e => e.langue1)
                .IsUnicode(false);

            modelBuilder.Entity<motif>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<motif>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<motif>()
                .HasMany(e => e.rendezvous)
                .WithOptional(e => e.motif1)
                .HasForeignKey(e => e.motif_id);

            modelBuilder.Entity<parcour>()
                .Property(e => e.doctorNote)
                .IsUnicode(false);

            modelBuilder.Entity<parcour>()
                .Property(e => e.justification)
                .IsUnicode(false);

            modelBuilder.Entity<parcour>()
                .HasMany(e => e.treatments)
                .WithOptional(e => e.parcour)
                .HasForeignKey(e => e.parcours_id);

            modelBuilder.Entity<parcour>()
                .HasMany(e => e.rendezvous)
                .WithOptional(e => e.parcour)
                .HasForeignKey(e => e.parcours_id);

            modelBuilder.Entity<parcour>()
                .HasMany(e => e.patients)
                .WithOptional(e => e.parcour)
                .HasForeignKey(e => e.parcours_id);

            modelBuilder.Entity<patient>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.token)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.numAppart)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.rendezvous)
                .WithOptional(e => e.patient)
                .HasForeignKey(e => e.patient_id);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tarif>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tarif>()
                .HasMany(e => e.doctors)
                .WithMany(e => e.tarifs)
                .Map(m => m.ToTable("doctor_tarifs").MapLeftKey("tarifs_id"));

            modelBuilder.Entity<treatment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<treatment>()
                .Property(e => e.result)
                .IsUnicode(false);
        }
    }
}

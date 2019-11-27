namespace PortfolioWebPage.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DoctorAppointmentModel : DbContext
    {
        public DoctorAppointmentModel()
            : base("name=DoctorAppointmentModel")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .Property(e => e.userID)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.doc_id)
                .WillCascadeOnDelete(false);
        }
    }
}

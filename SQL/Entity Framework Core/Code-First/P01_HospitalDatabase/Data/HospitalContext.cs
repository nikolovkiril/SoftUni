using P01_HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase.Data 
{

    public class HospitalContext : DbContext
    {

        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions optiops)
            : base(optiops)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
            }
        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(x => new { x.PatientId, x.MedicamentId });

                //pm
                //.HasOne(pm => pm.Medicament)
                //.WithMany(pm => pm.Prescriptions)
                //.HasForeignKey(pm => pm.MedicamentId);

                //pm
                //.HasOne(pm => pm.Patient)
                //.WithMany(p => p.Prescriptions)
                //.HasForeignKey(pm => pm.PatientId);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

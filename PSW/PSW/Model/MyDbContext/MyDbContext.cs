using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW.Model.Users;

namespace PSW.Model.MyDbContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<RegUser> RegUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<AppointmentHistory> AppointmentHistory { get; set; }

        public DbSet<Referral> Referrals { get; set; }

        public DbSet<ClinicFeedback> ClinicFeedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegUser>().ToTable("RegUser");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<AppointmentHistory>().ToTable("AppointmentHistory");
            modelBuilder.Entity<Referral>().ToTable("Referrals");
            modelBuilder.Entity<ClinicFeedback>().ToTable("ClinicFeedback");
        }

        public MyDbContext() { }

    }
}

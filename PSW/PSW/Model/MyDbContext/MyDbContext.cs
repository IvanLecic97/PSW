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

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public MyDbContext() { }

    }
}

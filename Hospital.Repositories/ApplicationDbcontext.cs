﻿using Hospital.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repositories
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HospitalInfo> HospitalInfos { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineReport> MedicineReports { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<Payroll> payrolls { get; set; }
        public DbSet<PerscribedMedicine> PerscribedMedicines { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TestPrice> TestPrice { get; set; }

    }
}

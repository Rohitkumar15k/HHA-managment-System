using HHAManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Caregiver> Caregivers => Set<Caregiver>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<CaregiverAssignment> CaregiverAssignments => Set<CaregiverAssignment>();
    public DbSet<Visit> Visits => Set<Visit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CaregiverAssignment>()
            .HasOne(x => x.Caregiver)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.CaregiverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CaregiverAssignment>()
            .HasOne(x => x.Patient)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Visit>()
            .HasOne(x => x.Caregiver)
            .WithMany(x => x.Visits)
            .HasForeignKey(x => x.CaregiverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Visit>()
            .HasOne(x => x.Patient)
            .WithMany(x => x.Visits)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using HHAManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.EnsureCreatedAsync();

        if (!await db.Users.AnyAsync())
        {
            db.Users.Add(new ApplicationUser
            {
                Username = "admin",
                Password = "Admin@123",
                Role = "Admin"
            });
        }

        if (!await db.Caregivers.AnyAsync())
        {
            db.Caregivers.AddRange(
                new Caregiver { FirstName = "John", LastName = "Smith", Email = "john@example.com", Phone = "9876543210", IsActive = true },
                new Caregiver { FirstName = "Sarah", LastName = "Brown", Email = "sarah@example.com", Phone = "9876501234", IsActive = true }
            );
        }

        if (!await db.Patients.AnyAsync())
        {
            db.Patients.AddRange(
                new Patient { FirstName = "Robert", LastName = "Miller", DateOfBirth = new DateTime(1958, 5, 12), Phone = "9000000001", Address = "12 Main Street" },
                new Patient { FirstName = "Mary", LastName = "Wilson", DateOfBirth = new DateTime(1964, 8, 23), Phone = "9000000002", Address = "25 Lake Road" }
            );
        }

        await db.SaveChangesAsync();
    }
}

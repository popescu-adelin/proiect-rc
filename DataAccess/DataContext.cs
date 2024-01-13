using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Clocking> Clocking { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Clocking) // Navigation property in Employee
            .WithOne(c => c.Employee)    // Navigation property in Clocking
            .HasForeignKey<Clocking>(c => c.EmployeeId); // Foreign key in Clocking

        modelBuilder.Entity<Employee>()
        .HasOne(e => e.Clocking)
        .WithOne(c => c.Employee)
        .HasForeignKey<Employee>(e => e.ClockingId);

    }

}

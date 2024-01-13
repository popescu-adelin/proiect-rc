using DataAccess.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class Employee
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string CardId { get; set; }

    public EmployeeStatusType Status { get; set; } = EmployeeStatusType.OutOfOffice;

    public Guid? ClockingId { get; set; }

    public Clocking? Clocking { get; set; }
}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CardId)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(e => e.CardId)
            .IsUnique();

        builder.HasOne(e => e.Clocking)
            .WithOne(c => c.Employee)
            .HasForeignKey<Employee>(e => e.ClockingId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

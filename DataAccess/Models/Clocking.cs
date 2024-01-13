using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class Clocking
{
    public Guid Id { get; set; }

    public DateTime ArivingTime { get; set; }

    public DateTime? LeavingTime { get; set; }

    public TimeSpan? WorkTime { get; set; }

    public Guid EmployeeId { get; set; }

    public Employee Employee { get; set; }
}


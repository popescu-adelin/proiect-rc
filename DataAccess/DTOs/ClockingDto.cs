using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs;

public class ClockingDto
{
    public Guid Id { get; set; }

    public DateTime ArivingTime { get; set; }

    public DateTime? LeavingTime { get; set; }

    public TimeSpan? WorkTime { get; set; }
}

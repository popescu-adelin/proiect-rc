using DataAccess.Models;
using DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs;

public class EmployeeDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string CardId { get; set; }

    public EmployeeStatusType Status { get; set; } = EmployeeStatusType.OutOfOffice;

    public Guid? ClockingId { get; set; }

    public ClockingDto? Clocking { get; set; }
}

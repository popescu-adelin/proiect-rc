using AutoMapper;
using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers;

public class ServiceProfiler : Profile
{
    public ServiceProfiler()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Clocking, ClockingDto>().ReverseMap();
    }
}

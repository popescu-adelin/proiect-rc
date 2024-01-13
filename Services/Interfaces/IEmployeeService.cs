using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces;

public interface IEmployeeService
{
    public Task<EmployeeDto> AddEmployeeAsync(RegisterData registerData);

    public ICollection<EmployeeDto> GetAll();
}

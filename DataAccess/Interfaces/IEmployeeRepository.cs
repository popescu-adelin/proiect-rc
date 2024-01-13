using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee?> GetByCardIdAsync(string cardId);

    public Task<Employee> AddEmployeeAsync(Employee employee);

    public Task<Employee> UpdateEmployeeAsync(Employee employee);

    public Task<Employee> UpdateEmployeeAndClockingAsync(Employee employee);

    public IQueryable<Employee> GetAll();
}

using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositoryes;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _dbContext;

    public EmployeeRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        var employeeEntity = await _dbContext.Employees.AddAsync(employee);

        await _dbContext.SaveChangesAsync();
        return employeeEntity.Entity;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        var updatedEmployee = _dbContext.Attach(employee);
        _dbContext.Entry(employee).State = EntityState.Modified;

        var clocking = _dbContext.Clocking.FirstOrDefault(c => c.EmployeeId == employee.Id);
        if (clocking != null)
        {
            _dbContext.Clocking.Remove(clocking);
        }

        await _dbContext.Clocking.AddAsync(employee.Clocking);
        await _dbContext.SaveChangesAsync();
        return updatedEmployee.Entity;
    }
    public async Task<Employee> UpdateEmployeeAndClockingAsync(Employee employee)
    {
        var updatedEmployee = _dbContext.Attach(employee);
        _dbContext.Entry(employee).State = EntityState.Modified;
        _dbContext.Clocking.Update(employee.Clocking);
        _dbContext.Entry(employee.Clocking).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return updatedEmployee.Entity;
    }

    public IQueryable<Employee> GetAll()
    {
        var employees = _dbContext.Employees
            .AsNoTracking()
            .AsQueryable();
        return employees;
    }
    //q: how to include the clocking?
    //a: use the include method
    //q: i'm using the include method, but it doesn't work
    //a: you need to use the asnotracking method
    public async Task<Employee?> GetByCardIdAsync(string cardId)
    {
        var employee = await _dbContext.Employees
            .Include(_ => _.Clocking)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.CardId == cardId);

        return employee;
    }
}

using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Types;
using Services.Hubs;
using Services.Interfaces;
namespace Services.Logic;

public class ClockingService : IClockingService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly EmployeeHub _employeeHub;
    private readonly IEmployeeService _employeeService;

    public ClockingService(IEmployeeRepository employeeRepository, EmployeeHub employeeHub, IEmployeeService employeeService)
    {
        _employeeRepository = employeeRepository;
        _employeeHub = employeeHub;
        _employeeService = employeeService;
    }

    //q: why is the employee not updated in the database?
    //a: because the employee is not saved in the database
    //q: why is the employee not saved in the database?
    //a: because the employee is not added to the database

    public async Task ProcessClocking(string cardId)
    {
        var employee = await _employeeRepository.GetByCardIdAsync(cardId);

        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        if (employee.Status == EmployeeStatusType.OutOfOffice)
        {
            var clocking = new Clocking
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                ArivingTime = DateTime.Now
            };

            employee.Clocking = clocking;

            employee.Status = EmployeeStatusType.Working;
            await _employeeRepository.UpdateEmployeeAsync(employee);
        } else
        {
            employee.Clocking.LeavingTime = DateTime.Now;
            employee.Clocking.WorkTime = employee.Clocking.LeavingTime - employee.Clocking.ArivingTime;
            employee.Status = EmployeeStatusType.OutOfOffice;
            await _employeeRepository.UpdateEmployeeAndClockingAsync(employee);
        }

        var employees = _employeeService.GetAll();

        await _employeeHub.SendEmployees(employees);
    }
}

using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace serverPontaj.Properties;

[Route("/api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = _employeeService.GetAll();
        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(RegisterData registerData)
    {
        var employee = await _employeeService.AddEmployeeAsync(registerData);
        return Ok(employee);
    }
}

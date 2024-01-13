using AutoMapper;
using DataAccess.DTOs;
using DataAccess.Interfaces;
using DataAccess.Models;
using Services.Interfaces;

namespace Services.Logic;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> AddEmployeeAsync(RegisterData registerData)
    {
        var employee = new Employee
        {
            Name = registerData.Name,
            CardId = registerData.CardId,
        };

        var addedEmployee = await _employeeRepository.AddEmployeeAsync(employee);
        var mappedEmployee = _mapper.Map<EmployeeDto>(addedEmployee);

        return mappedEmployee;
    }

    public ICollection<EmployeeDto> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        var mappedEmployees = _mapper.ProjectTo<EmployeeDto>(employees);
        var listOfEmployees = mappedEmployees.ToList();
        return listOfEmployees;
    }
}

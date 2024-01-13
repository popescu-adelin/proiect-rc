using DataAccess.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace Services.Hubs;

public class EmployeeHub : Hub
{
    public async Task SendEmployees(ICollection<EmployeeDto> employees)
    {
        if (employees == null)
        {
            throw new ArgumentNullException(nameof(employees));
        }

        await Clients.All.SendAsync("New clocking", employees);
    }
}

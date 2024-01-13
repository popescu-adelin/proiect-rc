using DataAccess;
using Microsoft.EntityFrameworkCore;
using serverPontaj.Infrastructure;
using Services.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.RegisterDataAccessDependencies(builder.Configuration);


builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // the Angular app url
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();
app.MapHub<EmployeeHub>("/clocking");

app.Run();

using Microsoft.EntityFrameworkCore;
using ReportService.Data.Models;
using ReportService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ReportServiceDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MyPostgreSQLDbConnection"), b => b.MigrationsAssembly("ReportService.Data")));
builder.Services.AddSingleton<IReportService, ReportService.Services.Repositories.ReportService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

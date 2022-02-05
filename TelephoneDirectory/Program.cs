using Microsoft.EntityFrameworkCore;
using TelephoneDirectory.Data.Models;
using TelephoneDirectory.Services.Interfaces;
using TelephoneDirectory.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add Migrations Configuration.
builder.Services.AddDbContext<TelephoneDirectoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MyPostgreSQLDbConnection"), b => b.MigrationsAssembly("TelephoneDirectory.Data")));
builder.Services.AddScoped<DbContext>(provider => provider.GetService<TelephoneDirectoryContext>());
builder.Services.AddSingleton<IUserService, UserService>();

// Add services to the container.

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

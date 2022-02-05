using Microsoft.EntityFrameworkCore;
using ReportService.API.Messaging.Options;
using ReportService.API.Messaging.Receiver;
using ReportService.API.Messaging.Sender;
using ReportService.Data.Models;
using ReportService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var serviceClientSettingsConfig = builder.Configuration.GetSection("RabbitMq");
var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMQConfiguration>();
builder.Services.Configure<RabbitMQConfiguration>(serviceClientSettingsConfig);

// Add services to the container.
builder.Services.AddDbContext<ReportServiceDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MyPostgreSQLDbConnection"), b => b.MigrationsAssembly("ReportService.Data")));
builder.Services.AddScoped<DbContext>(provider => provider.GetService<ReportServiceDbContext>());
builder.Services.AddScoped<IReportService, ReportService.Services.Repositories.ReportService>();
builder.Services.AddSingleton<IReportRequestSender, ReportRequestSender>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (serviceClientSettings.Enabled)
{
    builder.Services.AddHostedService<ReportRequestReceiver>();
}

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

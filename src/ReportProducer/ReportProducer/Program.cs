using Hangfire;
using ReportProducer.Extensions;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config DI
builder.Services.ConfigureDependencyInjection();

// Config DB
builder.Services.ConfigureDataBase();

// Config Hangfire
builder.Services.ConfigureHangfire();

builder.Services.AddHangfireServer();
    

var app = builder.Build();

app.CreateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Mapping dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilterExtension() }
});

app.MapGet("/", context =>
{
    context.Response.Redirect("/hangfire");
    return Task.CompletedTask;
});

app.ConfiureJobs();

app.Run();
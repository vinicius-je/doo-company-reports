using Hangfire;
using System;
using ConsumerWObserver.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddHangfireServer();
    

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

// Mapping dashboard
// app.UseHangfireDashboard("/hangfire", new DashboardOptions
// {
//     Authorization = new[] { new HangfireAuthorizationFilterExtension() }
// });
//
// app.MapGet("/", context =>
// {
//     context.Response.Redirect("/hangfire");
//     return Task.CompletedTask;
// });

// Configurando o Observer
var reportFilesDirectory = Path.Combine(AppContext.BaseDirectory, "ReportFiles");
Console.WriteLine(reportFilesDirectory);
var notifier = new ConsumerWObserver.Observers.FileSystemNotifier("C:\\Users\\craft\\OneDrive\\Documentos\\Faculdade\\doo-company-reports\\src\\ReportProducer\\ReportProducer\\ReportFiles");

// Registrando Observadores
notifier.RegisterObserver(new ConsumerWObserver.Observers.NewFileObserver());
notifier.RegisterObserver(new ConsumerWObserver.Observers.ValidationObserver());

Console.WriteLine("Observador de arquivos ativado.");



app.Run();
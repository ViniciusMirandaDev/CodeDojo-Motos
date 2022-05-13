using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MotoDojo.Context;
using MotoDojo.Repositories;
using MotoDojo.Services;
using Newtonsoft.Json;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IMotoRepository, MotoAdoNetRepository>();

builder.Services.AddDbContext<CoreContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .UseLazyLoadingProxies();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        var json = new
        {
            StatusCode = context.Response.StatusCode,
            Message = exceptionHandlerPathFeature?.Error.Message
        };

        await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

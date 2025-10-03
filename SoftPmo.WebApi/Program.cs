using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Behaviros;
using SoftPmo.Application.Services.System;
using SoftPmo.Persistance.Context;
using SoftPmo.Persistance.Services.System;
using SoftPmo.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ====================================
// SERVICE REGISTRATIONS
// ====================================

// System Services
builder.Services.AddScoped<ICodeTemplateService, CodeTemplateService>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Middleware
builder.Services.AddTransient<ExceptionMiddleware>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(SoftPmo.Persistance.AssemblyReference).Assembly);

// Database
string connectionString = builder.Configuration.GetConnectionString("NewPmoDb");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Controllers
builder.Services.AddControllers()
    .AddApplicationPart(typeof(SoftPmo.Presentation.AssemblyReference).Assembly);

// MediatR
builder.Services.AddMediatR(cfr =>
    cfr.RegisterServicesFromAssembly(typeof(SoftPmo.Application.AssemblyReference).Assembly));

// FluentValidation
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(SoftPmo.Application.AssemblyReference).Assembly);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ====================================
// MIDDLEWARE PIPELINE
// ====================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

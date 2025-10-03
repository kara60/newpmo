using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Behaviros;
using SoftPmo.Application.Services.System;
using SoftPmo.Persistance.Context;
using SoftPmo.Persistance.Services.System;
using SoftPmo.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICodeTemplateService, CodeTemplateService>();
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddAutoMapper(typeof(SoftPmo.Persistance.AssemblyReference).Assembly);

string connectionString = builder.Configuration.GetConnectionString("NewPmoDb");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(SoftPmo.Presentation.AssemblyReference).Assembly);

builder.Services.AddMediatR(cfr =>
    cfr.RegisterServicesFromAssembly(typeof(SoftPmo.Application.AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(SoftPmo.Application.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

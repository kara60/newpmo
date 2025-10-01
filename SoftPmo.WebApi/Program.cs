using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Services.System;
using SoftPmo.Persistance.Context;
using SoftPmo.Persistance.Services.System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICodeTemplateService, CodeTemplateService>();

builder.Services.AddAutoMapper(typeof(SoftPmo.Persistance.AssemblyReference).Assembly);

string connectionString = builder.Configuration.GetConnectionString("NewPmoDb");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(SoftPmo.Presentation.AssemblyReference).Assembly);

builder.Services.AddMediatR(cfr =>
    cfr.RegisterServicesFromAssembly(typeof(SoftPmo.Application.AssemblyReference).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

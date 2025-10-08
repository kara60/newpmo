using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Behaviros;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Application.Services.HumanResources;
using SoftPmo.Application.Services.NotificationM;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Persistance.Context;
using SoftPmo.Persistance.Services.ActivityM;
using SoftPmo.Persistance.Services.CustomerM;
using SoftPmo.Persistance.Services.HumanResources;
using SoftPmo.Persistance.Services.NotificationM;
using SoftPmo.Persistance.Services.ProjectM;
using SoftPmo.Persistance.Services.SystemBase;
using SoftPmo.Persistance.Services.TaskM;
using SoftPmo.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ====================================
// SERVICE REGISTRATIONS
// ====================================

// DI
builder.Services.AddScoped<ICodeTemplateService, CodeTemplateService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ILocationTypeService, LocationTypeService>();
builder.Services.AddScoped<IPositionLevelService, PositionLevelService>();
builder.Services.AddScoped<IPriorityService, PriorityService>();
builder.Services.AddScoped<ITaskStatusTypeService, TaskStatusTypeService>();
builder.Services.AddScoped<ITaskTypeService, TaskTypeService>();
builder.Services.AddScoped<ITaskStatusService, TaskStatusService>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IProjectTypeService, ProjectTypeService>();
builder.Services.AddScoped<IProjectStatusService, ProjectStatusService>();
builder.Services.AddScoped<IProjectRoleService, ProjectRoleService>();
builder.Services.AddScoped<ISystemParameterService, SystemParameterService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerLocationService, CustomerLocationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectTeamMemberService, ProjectTeamMemberService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IActivityService, ActivityService>();

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

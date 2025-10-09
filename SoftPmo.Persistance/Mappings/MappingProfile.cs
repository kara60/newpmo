using AutoMapper;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.UpdateActivity;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.UpdateCustomerLocation;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.UpdateProject;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.UpdateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;
using SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Commands.CreateCodeTemplate;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.CreateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;
using SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.CreateLocation;
using SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.UpdateLocation;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.UpdateLocationType;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.UpdatePositionLevel;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateSystemParameter;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.UpdateTask;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.UpdateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Notification;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CodeTemplate mapping
            CreateMap<CreateCodeTemplateCommand, CodeTemplate>().ReverseMap();

            // Location mapping
            CreateMap<CreateLocationCommand, Location>();
            CreateMap<UpdateLocationCommand, Location>();

            // LocationType mapping
            CreateMap<CreateLocationTypeCommand, LocationType>();
            CreateMap<UpdateLocationTypeCommand, LocationType>();

            // Department mapping
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();

            // Position mapping
            CreateMap<CreatePositionCommand, Position>();
            CreateMap<UpdatePositionCommand, Position>();

            // PositionLevel mapping
            CreateMap<CreatePositionLevelCommand, PositionLevel>();
            CreateMap<UpdatePositionLevelCommand, PositionLevel>();

            // Priority mapping
            CreateMap<CreatePriorityCommand, Priority>();
            CreateMap<UpdatePriorityCommand, Priority>();

            // TaskStatusType mapping
            CreateMap<CreateTaskStatusTypeCommand, TaskStatusType>();
            CreateMap<UpdateTaskStatusTypeCommand, TaskStatusType>();

            // TaskType mapping
            CreateMap<CreateTaskTypeCommand, TaskType>();
            CreateMap<UpdateTaskTypeCommand, TaskType>();

            // TaskStatus mapping
            CreateMap<CreateTaskStatusCommand, Domain.Entities.Task.TaskStatus>();
            CreateMap<UpdateTaskStatusCommand, Domain.Entities.Task.TaskStatus>();

            // Step mapping
            CreateMap<CreateStepCommand, Step>();
            CreateMap<UpdateStepCommand, Step>();

            // ProjectType mapping
            CreateMap<CreateProjectTypeCommand, ProjectType>();
            CreateMap<UpdateProjectTypeCommand, ProjectType>();

            // ProjectStatus mapping
            CreateMap<CreateProjectStatusCommand, ProjectStatus>();
            CreateMap<UpdateProjectStatusCommand, ProjectStatus>();

            // ProjectRole mapping
            CreateMap<CreateProjectRoleCommand, ProjectRole>();
            CreateMap<UpdateProjectRoleCommand, ProjectRole>();

            // SystemParameter mapping
            CreateMap<CreateSystemParameterCommand, SystemParameter>();
            CreateMap<UpdateSystemParameterCommand, SystemParameter>();

            // CustomerM mapping
            CreateMap<CreateCustomerCommand, CustomerM>();
            CreateMap<UpdateCustomerCommand, CustomerM>();

            // CustomerLocation mapping
            CreateMap<CreateCustomerLocationCommand, CustomerLocation>();
            CreateMap<UpdateCustomerLocationCommand, CustomerLocation>();

            // User mapping
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            // ProjectM mapping
            CreateMap<CreateProjectCommand, ProjectM>();
            CreateMap<UpdateProjectCommand, ProjectM>();

            // ProjectTeamMember mapping
            CreateMap<CreateProjectTeamMemberCommand, ProjectTeamMember>();
            CreateMap<UpdateProjectTeamMemberCommand, ProjectTeamMember>();

            // NotificationM mapping
            CreateMap<CreateNotificationCommand, NotificationM>();

            CreateMap<CreateTaskCommand, TaskM>();
            CreateMap<UpdateTaskCommand, TaskM>();

            // ActivityM mapping
            CreateMap<CreateActivityCommand, ActivityM>();
            CreateMap<UpdateActivityCommand, ActivityM>();
        }
    }
}
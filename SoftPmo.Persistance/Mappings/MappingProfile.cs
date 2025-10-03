using AutoMapper;
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
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;
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
        }
    }
}

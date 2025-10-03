using AutoMapper;
using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.CreateCodeTemplate;
using SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;
using SoftPmo.Application.Features.LocationFeatures.Commands.UpdateLocation;
using SoftPmo.Domain.Entities.System;

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
        }
    }
}

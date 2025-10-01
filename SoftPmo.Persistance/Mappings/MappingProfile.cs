using AutoMapper;
using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Persistance.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCodeTemplateCommand, CodeTemplate>().ReverseMap();
        }
    }
}

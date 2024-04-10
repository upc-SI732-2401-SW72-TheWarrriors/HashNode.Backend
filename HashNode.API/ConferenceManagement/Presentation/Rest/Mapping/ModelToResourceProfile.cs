using AutoMapper;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Presentation.Rest.Mapping.Resources;
namespace HashNode.API.ConferenceManagement.Presentation.Rest.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Conference, ConferenceResource>();
        }
    }
}

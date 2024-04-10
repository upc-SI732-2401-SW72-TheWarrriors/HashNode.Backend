using AutoMapper;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Presentation.Rest.Mapping.Resources;

namespace HashNode.API.ConferenceManagement.Presentation.Rest.Mapping
{
    public class ResourceToCommandProfile : Profile
    {
        public ResourceToCommandProfile()
        {
            CreateMap<CreateConferenceResource, CreateConferenceCommand>();
            CreateMap<UpdateConferenceResource, UpdateConferenceCommand>();
        }
    }
}

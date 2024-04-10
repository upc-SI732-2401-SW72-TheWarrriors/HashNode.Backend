using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Domain.Queries;

namespace HashNode.API.ConferenceManagement.Domain.Services
{
    public interface IConferenceQueryService
    {
        Task<Conference> handle(GetConferenceByIdQuery query);
        Task<Conference> handle(GetConferenceByTitleQuery query);
        Task<IEnumerable<Conference>> handle(GetAllConferenceQuery query);
    }
}

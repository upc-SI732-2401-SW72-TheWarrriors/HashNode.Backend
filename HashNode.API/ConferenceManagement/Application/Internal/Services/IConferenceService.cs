using HashNode.API.ConferenceManagement.Domain.Services.Communication;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using System.Threading.Tasks;

namespace HashNode.API.ConferenceManagement.Application.Internal.Services
{
    public interface IConferenceService
    {
        Task<ConferenceResponse> CreateConference(CreateConferenceCommand command);
        Task<ConferenceResponse> UpdateConference(string id, UpdateConferenceCommand command);
        Task<ConferenceResponse> DeleteConference(DeleteConferenceCommand command);
        Task<Conference> GetConferenceById(string conferenceId);
        Task<Conference> GetConferenceByTitle(string title);
        Task<IEnumerable<Conference>> GetAllConferences();
    }
}

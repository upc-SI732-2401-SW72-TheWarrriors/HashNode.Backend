using HashNode.API.ConferenceManagement.Domain.Models.Entities;

namespace HashNode.API.ConferenceManagement.Domain.Repositories
{
    public interface IConferenceRepository
    {
        Task<IEnumerable<Conference>> ListAllConferencesAsync();
        Task CreateConferenceAsync(Conference newConference);
        bool ConferenceExists(string conferenceId);
        Task<Conference> FindConferenceByIdAsync(string conferenceId);
        Task<Conference> FindConferenceByTitleAsync(string title);
        Task UpdateAsync(Conference updatedConference);
        Task DeleteAsync(Conference deleteConference);
    }
}

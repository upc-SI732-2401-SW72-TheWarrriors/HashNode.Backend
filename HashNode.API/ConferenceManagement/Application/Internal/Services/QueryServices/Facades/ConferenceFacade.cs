using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Domain.Repositories;

namespace HashNode.API.ConferenceManagement.Application.Internal.Services.QueryServices.Facades
{
    public interface IConferenceQueryFacade
    {
        Task<Conference> GetConferenceByIdAsync(string conferenceId);
        Task<Conference> GetConferenceByTitleAsync(string title);
        Task<IEnumerable<Conference>> GetAllConferencesAsync();
    }

    public class ConferenceQueryFacade : IConferenceQueryFacade
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceQueryFacade(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        public async Task<Conference> GetConferenceByIdAsync(string conferenceId)
        {
            return await _conferenceRepository.FindConferenceByIdAsync(conferenceId);
        }

        public async Task<Conference> GetConferenceByTitleAsync(string title)
        {
            return await _conferenceRepository.FindConferenceByTitleAsync(title);
        }

        public async Task<IEnumerable<Conference>> GetAllConferencesAsync()
        {
            return await _conferenceRepository.ListAllConferencesAsync();
        }
    }
}

using HashNode.API.ConferenceManagement.Domain.Queries;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Domain.Services;
using HashNode.API.ConferenceManagement.Application.Internal.Services.QueryServices.Facades;

namespace HashNode.API.ConferenceManagement.Application.Internal.Services.QueryServices
{
    public class ConferenceQueryServiceImpl : IConferenceQueryService
    {
        private readonly IConferenceQueryFacade _conferenceQueryFacade;

        public ConferenceQueryServiceImpl(IConferenceQueryFacade conferenceQueryFacade)
        {
            _conferenceQueryFacade = conferenceQueryFacade;
        }

        public async Task<Conference> handle(GetConferenceByIdQuery query)
        {
            return await _conferenceQueryFacade.GetConferenceByIdAsync(query.ConferenceId);
        }

        public async Task<Conference> handle(GetConferenceByTitleQuery query)
        {
            return await _conferenceQueryFacade.GetConferenceByTitleAsync(query.Title);
        }

        public async Task<IEnumerable<Conference>> handle(GetAllConferenceQuery query)
        {
            return await _conferenceQueryFacade.GetAllConferencesAsync();
        }
    }
}

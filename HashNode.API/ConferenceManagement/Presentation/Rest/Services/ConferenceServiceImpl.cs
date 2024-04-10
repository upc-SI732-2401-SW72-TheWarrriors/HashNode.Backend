using HashNode.API.ConferenceManagement.Application.Internal.Services;
using HashNode.API.ConferenceManagement.Domain.Services.Communication;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Domain.Queries;
using HashNode.API.ConferenceManagement.Domain.Services;

namespace HashNode.API.ConferenceManagement.Presentation.Rest.Services
{
    public class ConferenceServiceImpl : IConferenceService
    {
        private readonly IConferenceCommandService _commandService;
        private readonly IConferenceQueryService _queryService;

        public ConferenceServiceImpl(IConferenceCommandService commandService, IConferenceQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        public Task<ConferenceResponse> CreateConference(CreateConferenceCommand command)
        {
            return _commandService.handle(command);
        }

        public Task<ConferenceResponse> UpdateConference(string id, UpdateConferenceCommand command)
        {
            return _commandService.handle(id, command);
        }

        public Task<ConferenceResponse> DeleteConference(DeleteConferenceCommand command)
        {
            return _commandService.handle(command);
        }

        public Task<Conference> GetConferenceById(string conferenceId)
        {
            return _queryService.handle(new GetConferenceByIdQuery(conferenceId));
        }

        public Task<Conference> GetConferenceByTitle(string title)
        {
            return _queryService.handle(new GetConferenceByTitleQuery(title));
        }

        public Task<IEnumerable<Conference>> GetAllConferences()
        {
            return _queryService.handle(new GetAllConferenceQuery());
        }
    }
}

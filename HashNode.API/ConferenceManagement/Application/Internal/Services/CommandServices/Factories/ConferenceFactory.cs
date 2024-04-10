using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;

namespace HashNode.API.ConferenceManagement.Application.Internal.Services.Factories
{
    public interface IConferenceCommandFactory
    {
        Conference CreateConference(CreateConferenceCommand command);
    }
    public class ConferenceFactory : IConferenceCommandFactory
    {
        public Conference CreateConference(CreateConferenceCommand command)
        {
            var conference = new Conference(
                title: command.Title,
                description: command.Description
                );

            return conference;
        }
    }
}

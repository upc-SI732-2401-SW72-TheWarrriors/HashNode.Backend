using HashNode.API.ConferenceManagement.Domain.Services.Communication;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using System.Runtime.InteropServices;

namespace HashNode.API.ConferenceManagement.Domain.Services
{
    public interface IConferenceCommandService
    {
        Task<ConferenceResponse> handle(CreateConferenceCommand command);
        Task<ConferenceResponse> handle(string id, UpdateConferenceCommand command);
        Task<ConferenceResponse> handle(DeleteConferenceCommand command);
    }
}

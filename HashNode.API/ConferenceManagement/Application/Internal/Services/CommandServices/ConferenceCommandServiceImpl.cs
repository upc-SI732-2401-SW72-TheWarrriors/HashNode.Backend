using HashNode.API.ConferenceManagement.Application.Internal.Services.Factories;
using HashNode.API.ConferenceManagement.Domain.Services.Communication;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Repositories;
using HashNode.API.ConferenceManagement.Domain.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace HashNode.API.ConferenceManagement.Application.Internal.Services.CommandServices
{
    public class ConferenceCommandServiceImpl : IConferenceCommandService
    {
        private readonly IConferenceRepository conferenceRepository;
        private readonly IConferenceCommandFactory conferenceFactory;

        public ConferenceCommandServiceImpl(IConferenceRepository conferenceRepository, IConferenceCommandFactory conferenceFactory)
        {
            this.conferenceRepository = conferenceRepository;
            this.conferenceFactory = conferenceFactory;
        }

        public async Task<ConferenceResponse> handle(CreateConferenceCommand command)
        {
            
            var newConference = conferenceFactory.CreateConference(command);
            try
            {
                await conferenceRepository.CreateConferenceAsync(newConference);
                return new ConferenceResponse(newConference);
            }
            catch (Exception ex)
            {
                return new ConferenceResponse($"An error occurred while creating the conference: {ex.Message}");
            }
        }

        public async Task<ConferenceResponse> handle(string id, UpdateConferenceCommand command)
        {
            var existingConference = await conferenceRepository.FindConferenceByIdAsync(id);
            if (existingConference == null)
            {
                return new ConferenceResponse("Conference not found");
            }

            existingConference.SaveConference(command.Title, command.Description);

            try
            {
                await conferenceRepository.UpdateAsync(existingConference);
                return new ConferenceResponse(existingConference);
            }
            catch (Exception ex)
            {
                return new ConferenceResponse($"An error occurred while updating the conference: {ex.Message}");
            }
        }


        public async Task<ConferenceResponse> handle(DeleteConferenceCommand command)
        {
            if (!conferenceRepository.ConferenceExists(command.conferenceId))
            {
                return new ConferenceResponse("Conference not found");
            }
            try
            {
                var existingConference = await conferenceRepository.FindConferenceByIdAsync(command.conferenceId);
                await conferenceRepository.DeleteAsync(existingConference);
                return new ConferenceResponse(existingConference);
            }
            catch (Exception ex)
            {
                return new ConferenceResponse($"An error occurred while deleting the conference : {ex.Message}");
            }
        }
    }
}

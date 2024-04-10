using AutoMapper;
using HashNode.API.ConferenceManagement.Application.Internal.Services;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Presentation.Rest.Mapping.Resources;
using HashNode.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace HashNode.API.ConferenceManagement.Presentation.Rest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Conference Management")]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService _conferenceService;
        private readonly IMapper _mapper;

        public ConferenceController(IConferenceService eventService, IMapper mapper)
        {
            _conferenceService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ConferenceResource>> GetAllConferencesAsync()
        {
            var conferences = await _conferenceService.GetAllConferences();
            return _mapper.Map<IEnumerable<Conference>, IEnumerable<ConferenceResource>>(conferences);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetConferenceByTitleAsync(string title)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var conference = await _conferenceService.GetConferenceByTitle(title);
            if (conference == null)
                return NotFound();
            return Ok(_mapper.Map<ConferenceResource>(conference));

        }

        [HttpPost]
        public async Task<IActionResult> CreateNewConferenceAsync([FromBody] CreateConferenceResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<CreateConferenceResource, CreateConferenceCommand>(resource);
            var response = await _conferenceService.CreateConference(command);
            if (!response.Success)
                return BadRequest(response.Message);
            var conferenceResource = _mapper.Map<Conference, ConferenceResource>(response.Resource);
            return Created(nameof(CreateNewConferenceAsync), conferenceResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConferenceAsync(string id, [FromBody] UpdateConferenceResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<UpdateConferenceResource, UpdateConferenceCommand>(resource);
            var response = await _conferenceService.UpdateConference(id, command);
            if (!response.Success)
                return NotFound();
            var conferenceResource = _mapper.Map<Conference, ConferenceResource>(response.Resource);
            return Ok(conferenceResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferenceAsync(string id)
        {
            var command = new DeleteConferenceCommand(id);
            var response = await _conferenceService.DeleteConference(command);
            if (!response.Success)
                return NotFound();
            return NoContent();
        }
    }
}

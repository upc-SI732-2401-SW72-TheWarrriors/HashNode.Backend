using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.Shared.Domain.Services.Communication;

namespace HashNode.API.ConferenceManagement.Domain.Services.Communication
{
    public class ConferenceResponse : BaseResponse<Conference>
    {
        public ConferenceResponse(Conference resource) : base(resource)
        {
        }

        public ConferenceResponse(string message) : base(message)
        {
        }
    }
}

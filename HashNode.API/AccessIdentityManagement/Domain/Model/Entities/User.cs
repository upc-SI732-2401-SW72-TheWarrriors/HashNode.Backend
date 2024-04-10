using HashNode.API.ConferenceManagement.Domain.Models.Entities;

namespace HashNode.API.UserManagement.Domain.Model.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

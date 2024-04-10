using HashNode.API.FeedManagement.Domain.Models.Entities;

namespace HashNode.API.UserManagement.Domain.Model.Entities
{
    public class Profile
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
    }
}

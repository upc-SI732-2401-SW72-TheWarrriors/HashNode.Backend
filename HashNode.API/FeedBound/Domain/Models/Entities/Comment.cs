using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.FeedManagement.Domain.Models.Entities
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relationship
        public string PostId { get; set; }
        public Post Post { get; set; }
    }
}

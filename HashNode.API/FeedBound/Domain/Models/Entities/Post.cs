using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.FeedManagement.Domain.Models.Entities
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        // Relationship
        public List<Comment> Comments { get; set; }
    }
}

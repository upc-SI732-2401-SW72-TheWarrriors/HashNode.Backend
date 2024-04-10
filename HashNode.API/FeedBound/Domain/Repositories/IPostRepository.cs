using HashNode.API.FeedManagement.Domain.Models.Entities;

namespace HashNode.API.FeedManagement.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> ListAllPostsAsync();
        Task CreatePostAsync(Post newPost);
        Task<Post> FindPostByIdAsync(string postId);
        void Update(Post updatedPost);
        void Delete(Post deletePost);
    }
}

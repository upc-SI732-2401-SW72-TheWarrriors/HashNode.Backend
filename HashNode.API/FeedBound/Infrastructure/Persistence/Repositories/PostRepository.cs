using HashNode.API.FeedManagement.Domain.Models.Entities;
using HashNode.API.FeedManagement.Domain.Repositories;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using HashNode.API.Shared.Infrastructure.Persistence.Repositories;

namespace HashNode.API.FeedManagement.Infrastructure.Persistence.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task CreatePostAsync(Post newPost)
        {
            throw new NotImplementedException();
        }

        public void Delete(Post deletePost)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> FindPostByIdAsync(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> ListAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Post updatedPost)
        {
            throw new NotImplementedException();
        }
    }
}

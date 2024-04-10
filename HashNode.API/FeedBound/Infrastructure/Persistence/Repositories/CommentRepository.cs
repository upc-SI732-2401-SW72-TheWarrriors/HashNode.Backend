using HashNode.API.FeedManagement.Domain.Models.Entities;
using HashNode.API.FeedManagement.Domain.Repositories;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using HashNode.API.Shared.Infrastructure.Persistence.Repositories;

namespace HashNode.API.FeedManagement.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public Task CreateCommentAsync(Comment newComment)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment deleteComment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> FindCommentByIdAsync(string commentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> ListAllCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment updatedComment)
        {
            throw new NotImplementedException();
        }
    }
}

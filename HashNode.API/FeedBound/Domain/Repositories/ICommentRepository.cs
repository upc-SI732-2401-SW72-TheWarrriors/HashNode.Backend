using HashNode.API.FeedManagement.Domain.Models.Entities;

namespace HashNode.API.FeedManagement.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListAllCommentsAsync();
        Task<Comment> FindCommentByIdAsync(string commentId);
        Task CreateCommentAsync(Comment newComment);
        void Update(Comment updatedComment);
        void Delete(Comment deleteComment);
    }
}

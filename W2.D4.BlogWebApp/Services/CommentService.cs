using W2.D4.BlogWebApp.Entities;

namespace W2.D4.BlogWebApp.Services
{
    public class CommentService : CrudService<Comment>, ICommentService
    {
        public IEnumerable<Comment> GetAll(int entityId) =>
            entities.Where(e => e.Article.Id == entityId);
    }
}

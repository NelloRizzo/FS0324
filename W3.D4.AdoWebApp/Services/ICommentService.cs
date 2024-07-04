using W3.D4.AdoWebApp.Models;

namespace W3.D4.AdoWebApp.Services
{
    public interface ICommentService
    {
        void WriteComment(int articleId,  string comment);
        IEnumerable<Comment> GetAllComments(int articleId);
        Comment GetComment(int commentId);
        void UpdateComment(int commentId, string comment);
        void DeleteComment(int commentId);
    }
}

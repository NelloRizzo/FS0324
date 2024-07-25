using W8.D4.WebApi.DataLayer.Entities;

namespace W8.D4.WebApi.DataLayer.Dao.SqlServer
{
    public class CommentDao : BaseDao, ICommentDao
    {
        public CommentDao(IConfiguration config, ILogger<BaseDao> logger) : base(config, logger) {
        }

        public Task<CommentEntity> CreateAsync(CommentEntity entity) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> UpdateAsync(int id, CommentEntity entity) {
            throw new NotImplementedException();
        }
    }
}

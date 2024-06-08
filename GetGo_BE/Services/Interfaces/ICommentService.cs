using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Comment;

namespace GetGo_BE.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetLocationComment(int locationId);
        public Task CreateComment(CreateCommentRequest request);
    }
}

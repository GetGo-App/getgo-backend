using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetLocationComment(int locationId);
        public Task CreateComment(CreateCommentRequest request);
    }
}

using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Comment;
using GetGo.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class CommentRepository : BaseRepository<CommentRepository>, ICommentRepository
    {
        private readonly IMongoCollection<Comment> _comments;

        public CommentRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _comments = _database.GetCollection<Comment>("Comment");
        }

        public async Task<List<Comment>> GetLocationComment(string locationId)
        {
            return await _comments.Find(c => c.Location ==  locationId).ToListAsync();
        }

        public async Task CreateComment(CreateCommentRequest request)
        {
            Comment comment = new Comment(request.Content, request.Images, request.Rating, request.UserId, request.Location);
            await _comments.InsertOneAsync(comment);
        }
    }
}

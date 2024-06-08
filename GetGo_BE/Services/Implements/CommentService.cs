using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Comment;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class CommentService : BaseService<CommentService>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILocationRepository _locationRepository;

        public CommentService(ILogger<CommentService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICommentRepository commentRepository, ILocationRepository locationRepository) : base(logger, mapper, httpContextAccessor)
        {
            _commentRepository = commentRepository;
            _locationRepository = locationRepository;
        }

        public async Task CreateComment(CreateCommentRequest request)
        {
            await _commentRepository.CreateComment(request);
        }

        public async Task<List<Comment>> GetLocationComment(string locationId)
        {
            List<Comment> comments = await _commentRepository.GetLocationComment(locationId);
            return comments;
        }
    }
}

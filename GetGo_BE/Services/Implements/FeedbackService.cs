using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Feedback;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class FeedbackService : BaseService<FeedbackService>, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(ILogger<FeedbackService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, IFeedbackRepository feedbackRepository) : base(logger, mapper, httpContextAccessor)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task CreateFeedback(CreateFeedbackRequest request)
        {
            await _feedbackRepository.CreateFeedback(request);
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _feedbackRepository.GetAllFeedbacks();
        }

        public async Task<Feedback> GetFeedbackById(string id)
        {
            return await _feedbackRepository.GetFeedbackById(id);
        }
    }
}

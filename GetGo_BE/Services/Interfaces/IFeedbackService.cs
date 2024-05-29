using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Feedback;

namespace GetGo_BE.Services.Interfaces
{
    public interface IFeedbackService
    {
        public Task<List<Feedback>> GetAllFeedbacks();
        public Task<Feedback> GetFeedbackById(string id);
        public Task CreateFeedback(CreateFeedbackRequest request);
    }
}

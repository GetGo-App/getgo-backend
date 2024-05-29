using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        public Task<List<Feedback>> GetAllFeedbacks();
        public Task<Feedback> GetFeedbackById(string id);
        public Task CreateFeedback(CreateFeedbackRequest request);
    }
}

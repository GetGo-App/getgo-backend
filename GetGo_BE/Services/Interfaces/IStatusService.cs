using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;

namespace GetGo_BE.Services.Interfaces
{
    public interface IStatusService
    {
        public Task<List<Status>> GetAllStatus();
        public Task CreateStatus(CreateStatusRequest request);
        public Task<Status> GetStatusById(string id);
        public Task<List<Status>> GetUserStatus(string userId);
        public Task UpdateStatus(string id, UpdateStatusRequest request);
        public Task DeleteStatus(string id);
        public Task UpdateReaction(string id, UpdateReactionRequest request);
    }
}

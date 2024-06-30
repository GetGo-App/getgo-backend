using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IStatusRepository
    {
        public Task<List<Status>> GetAllStatus();
        public Task CreateStatus(CreateStatusRequest request);
        public Task<Status> GetStatusById(string id);
        public Task<List<Status>> GetUserStatus(string userId);
        public Task<List<Status>> GetFriendStatus(string userId);
        public Task UpdateStatus(string id, UpdateStatusRequest request);
        public Task DeleteStatus(string id);
        public Task UpdateReaction(string id, UpdateReactionRequest request);
    }
}

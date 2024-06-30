using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class StatusService : BaseService<StatusService>, IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        public StatusService(ILogger<StatusService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, IStatusRepository statusRepository) : base(logger, mapper, httpContextAccessor)
        {
            _statusRepository = statusRepository;
        }

        public async Task CreateStatus(CreateStatusRequest request)
        {
            await _statusRepository.CreateStatus(request);
        }

        public async Task DeleteStatus(string id)
        {
            await _statusRepository.DeleteStatus(id);
        }

        public async Task<Status> GetStatusById(string id)
        {
            return await _statusRepository.GetStatusById(id);
        }

        public async Task<List<Status>> GetUserStatus(string userId)
        {
            return await _statusRepository.GetUserStatus(userId);
        }

        public async Task UpdateStatus(string id, UpdateStatusRequest request)
        {
            await _statusRepository.UpdateStatus(id, request);
        }

        public async Task UpdateReaction(string id, UpdateReactionRequest request)
        {
            await _statusRepository.UpdateReaction(id, request);
        }

        public async Task<List<Status>> GetAllStatus()
        {
            return await _statusRepository.GetAllStatus();
        }
    }
}

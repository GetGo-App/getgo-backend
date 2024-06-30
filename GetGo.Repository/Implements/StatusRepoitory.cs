using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;
using GetGo.Repository.Interfaces;
using GetGo_BE.Enums.Image;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class StatusRepoitory : BaseRepository<StatusRepoitory>, IStatusRepository
    {
        private readonly IMongoCollection<Status> _status;
        public StatusRepoitory(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _status = _database.GetCollection<Status>("Status");
        }
        public async Task<List<Status>> GetAllStatus()
        {
            return await _status.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateStatus(CreateStatusRequest request)
        {
            Status status = new Status(request.Content, request.Images, request.Uploader, request.PrivacyMode);
            await _status.InsertOneAsync(status);
        }

        public async Task<Status> GetStatusById(string id)
        {
            return await _status.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Status>> GetUserStatus(string userId)
        {
            return await _status.Find(s => s.Uploader == userId ).ToListAsync();
        }

        public async Task<List<Status>> GetFriendStatus(string userId)
        {
            return await _status.Find(s => s.Uploader == userId && s.PrivacyMode.Equals(ImagePrivacyEnum.MySelf.ToString())).ToListAsync();
        }

        public async Task UpdateStatus(string id, UpdateStatusRequest request)
        {
            Status status = await _status.Find(s => s.Id == id).FirstOrDefaultAsync();

            status.Content = String.IsNullOrEmpty(request.Content) ? status.Content : request.Content;
            status.Images = request.Images == null ? status.Images : request.Images;
            status.PrivacyMode = String.IsNullOrEmpty(request.PrivacyMode) ? status.PrivacyMode : request.PrivacyMode;

            await _status.ReplaceOneAsync(s => s.Id == id, status);
        }

        public async Task DeleteStatus(string id)
        {
            FilterDefinition<Status> filterDefinition = Builders<Status>.Filter.Eq("Id", id);
            await _status.DeleteOneAsync(filterDefinition);
            return;
        }

        public async Task UpdateReaction(string id, UpdateReactionRequest request)
        {
            Status status = await _status.Find(s => s.Id == id).FirstOrDefaultAsync();
            //bool isUserReacted = status.ReactedUsers.FirstOrDefault(ru => ru.Equals(request.ReactedUserId)) != null;

            if(status.ReactedUsers == null) status.ReactedUsers = new List<string>();

            if(request.IsReacted)
            {
                status.ReactedUsers.Add(request.ReactedUserId);
            }
            else
            {
                status.ReactedUsers.Remove(request.ReactedUserId);
            }

            await _status.ReplaceOneAsync(s => s.Id == id, status);
        }
    }
}

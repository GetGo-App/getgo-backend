using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IMessageRepository
    {
        public Task CreateMessage(CreateMessageRequest request);
        public Task<List<Message>> GetUserMessageHistory(GetDialogMessageRequest request);
        public Task DeleteMessage(string id);
    }
}

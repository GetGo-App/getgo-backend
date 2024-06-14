﻿using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IAIMessageHistoryRepository
    {
        public Task<List<AIMessageHistory>> GetAIChatHistory(GetDialogMessageRequest request);
        public Task CreateAIMessageHistory(AIMessageHistory message);
    }
}

using MessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessagingAPI.Services.Interface
{
    public interface IMessageService
    {
        Task<List<MessageDTO>> GetAllMessages();

        Task<MessageDTO> GetMessage(Guid messageId);

        Task CreateMessage(MessageDTO message);

        Task UpdateMessage(Guid messageId, MessageDTO message);

        Task DeleteMessage(Guid messageId);
    }
}
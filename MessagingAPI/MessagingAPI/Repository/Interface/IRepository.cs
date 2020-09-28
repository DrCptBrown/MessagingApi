using MessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessagingAPI.Repository.Interface
{
    public interface IRepository
    {
        Task<List<MessageDTO>> GetAll();

        Task<MessageDTO> Get(Guid messageId);

        Task Create(MessageDTO message);

        Task Update(Guid messageId, MessageDTO message);

        Task Delete(Guid messageId);
    }
}
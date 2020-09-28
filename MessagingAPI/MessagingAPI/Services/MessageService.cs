using MessagingAPI.Models;
using MessagingAPI.Repository.Interface;
using MessagingAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessagingAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository _repository;

        public MessageService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MessageDTO>> GetAllMessages()
        {
            var messages = await _repository.GetAll();

            return messages;
        }

        public async Task<MessageDTO> GetMessage(Guid messageId)
        {
            var message = await _repository.Get(messageId);

            return message;
        }

        public async Task CreateMessage(MessageDTO message)
        {
            await _repository.Create(message);
        }

        public async Task UpdateMessage(Guid messageId, MessageDTO message)
        {
            await _repository.Update(messageId, message);
        }

        public async Task DeleteMessage(Guid messageId)
        {
            await _repository.Delete(messageId);
        }
    }
}
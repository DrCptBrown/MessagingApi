using System;
using System.ComponentModel.DataAnnotations;

namespace MessagingAPI.Models
{
    public class MessageDTO
    {
        public Guid MessageId { get; set; }

        [Required]
        public string Username { get; set; }

        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
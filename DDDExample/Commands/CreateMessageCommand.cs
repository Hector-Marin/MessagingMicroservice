using MediatR;
using Messaging.Domain.AggregatesModel.MessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messaging.API.Commands
{
    public class CreateMessageCommand : IRequest<bool>
    {
        public string Message { get; set; }
        public int UserId { get; set; }

        public CreateMessageCommand(string message, int userId)
        {
            Message = message;
            UserId = userId;
        }

        CreateMessageCommand() { }


        public class CreateMessageDTO
        {
            public string Id { get; private set; }
            public string Content { get; private set; }
            public DateTime CreatedAt { get; private set; }
            public DateTime UpdatedAt { get; private set; }
            public int UserId { get; private set; }
            public string Status { get; private set; }

            public CreateMessageDTO(string id, string content, DateTime createdAt, DateTime updatedAt, int userId, string status)
            {
                Id = id;
                Content = content;
                CreatedAt = createdAt;
                UpdatedAt = updatedAt;
                UserId = userId;
                Status = status;
            }
        }
    }
}

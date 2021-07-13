using MediatR;
using Messaging.Domain.AggregatesModel.MessageAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.Events
{
    public class MessageCreatedDomainEvent : INotification
    {
        public Message Message { get; }
        public MessageCreatedDomainEvent(Message message)
        {
            Message = message;
        }
    }
}

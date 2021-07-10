using MediatR;
using Messaging.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.API.DomainEventHandlers.MessageCreatedDomainEventHandler
{
    public class ValidateUserStatusWhenMessageCreatedDomainEventHandler :
        INotificationHandler<MessageCreatedDomainEvent>
    {
        public async Task Handle(MessageCreatedDomainEvent messageCreatedEvent, CancellationToken cancellationToken)
        {
            
        }
    }
}

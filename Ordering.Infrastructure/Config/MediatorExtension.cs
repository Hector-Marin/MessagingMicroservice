using MediatR;
using Messaging.Domain.SharedKernel;
using Messaging.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Infrastructure.Config
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator)
        {
            
            /*foreach (var domainEvent in e.DomainEvents)
            {
                await mediator.Publish(domainEvent);
            }*/
        }
    }
}

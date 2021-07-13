using MediatR;
using Messaging.Domain.AggregatesModel.MessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.API.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, bool>
    {
        private readonly IMessageRepository _repository;

        public CreateMessageCommandHandler(IMessageRepository messageRepository)
        {
            _repository = messageRepository;
        }
        public async Task<bool> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var content = new Content(request.Message);
            var user = new User(request.UserId);
            var message = new Message(content, user);
            _repository.Add(message);

            //Rabbit notification;
            return await _repository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}

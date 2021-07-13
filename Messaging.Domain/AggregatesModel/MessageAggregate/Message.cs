using Messaging.Domain.Events;
using Messaging.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.AggregatesModel.MessageAggregate
{
    public class Message : Entity, IAggregateRoot
    {

        public string Id { get; private set; }
        public Content Content { get; private set; }

        public MessageStatus Status { get; private set; }

        public User User { get; private set; }

        public Message(Content content, User user)
        {
            Status = MessageStatus.Pending;
            Content = content;
            User = user;

            AddMessageCreatedDomainEvent();
        }

        public Message(string id, Content content, MessageStatus status, User user)
        {
            Id = id;
            Content = content;
            Status = status;
            User = user;
        }

        public Message(string id)
        {
            Id = id;
        }

        public Message() { }

        public void SetContent(string text)
        {
            Content = new Content(text);
        }

        public void SetUser(int userId)
        {
            User = new User(userId);
        }

        public void SetStatus(string status)
        {
            Status = MessageStatus.FromDisplayName<MessageStatus>(status);
        }

        private void AddMessageCreatedDomainEvent()
        {
            var messageCeatedDomainEvent = new MessageCreatedDomainEvent(this);
            AddDomainEvent(messageCeatedDomainEvent);
        }
    }
}

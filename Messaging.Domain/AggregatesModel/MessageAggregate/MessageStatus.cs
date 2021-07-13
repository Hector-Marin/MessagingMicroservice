using Messaging.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.AggregatesModel.MessageAggregate
{
    public class MessageStatus : Enumeration
    {
        public static MessageStatus Accepted = new MessageStatus(1, nameof(Accepted));
        public static MessageStatus Pending = new MessageStatus(2, nameof(Pending));
        public static MessageStatus Rejected = new MessageStatus(3, nameof(Rejected));

        public MessageStatus(int id, string name) : base(id, name) {}
    }
}

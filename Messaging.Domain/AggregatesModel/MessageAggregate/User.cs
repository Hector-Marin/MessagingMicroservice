using Messaging.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.AggregatesModel.MessageAggregate
{
    public class User : Entity
    {
        public int Id { get; } 
        public User(int id)
        {
            Id = id;
        }
    }
}

using Messaging.Domain.SharedKernel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure.Models
{
    public interface IMongoContext : IUnitOfWork
    {
        IMongoCollection<MessageMongo> Messages { get; }
        public IClientSessionHandle Session { get; }
    }
}

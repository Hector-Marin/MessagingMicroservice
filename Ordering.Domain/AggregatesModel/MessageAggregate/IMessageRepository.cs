using Messaging.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Domain.AggregatesModel.MessageAggregate
{
    public interface IMessageRepository : IRepository<Message>
    {
        Message Add(Message order);

        void Update(Message order);

        Task<Message> GetAsync(string messageId);

        Task<IEnumerable<Message>> GetAllAsync(int userId);
    }
}

using Messaging.Domain.AggregatesModel.MessageAggregate;
using Messaging.Domain.SharedKernel;
using Messaging.Infrastructure.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoContext _context;
        private readonly IClientSessionHandle _session;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public MessageRepository(IMongoContext context)
        {
            _context = context;
            _session = context.Session;
            // ?? throw new ArgumentNullException(nameof(context));
        }

        public Message Add(Message message)
        {
            
            MessageMongo messageCreated = message;
            _context.Messages.InsertOneAsync(_session, messageCreated);
            return messageCreated;
        }


        public async Task<Message> GetAsync(string messageId)
        {
            var filter = Builders<MessageMongo>.Filter.Eq("Id", messageId);
            return await _context.Messages.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Message>> GetAllAsync(int userId)
        {
            var filter = Builders<MessageMongo>.Filter.Eq("UserId", userId);
            return  _context.Messages.Find(_ => true).ToEnumerable().Select(mMongo => (Message) mMongo);
        }

        public void Update(Message message)
        {
            var filter = Builders<MessageMongo>.Filter.Eq("Id", message.Id);
            _context.Messages.ReplaceOne(_session, filter, message);
        }
    }
}

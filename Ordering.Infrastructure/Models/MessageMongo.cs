using Messaging.Domain.AggregatesModel.MessageAggregate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure.Models
{
    public class MessageMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("UserId")]
        public int UserId { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        public MessageMongo(){}
        public MessageMongo(Message message)
        {
            Id = message.Id;
            Content = message.Content.Text;
            UserId = message.User.Id;
            Status = message.Status.Name;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public static implicit operator MessageMongo(Message message)
        {
            return new MessageMongo(message);
        }

        public static implicit operator Message(MessageMongo messageMongo)
        {
            var message = new Message(messageMongo.Id);
            message.SetContent(messageMongo.Content);
            message.SetUser(messageMongo.UserId);
            message.SetStatus(messageMongo.Status);

            return message;
        }
    }
}
